// completely use angularJS to refactor this JS application
var polygonManagerApp = angular.module("polygonManagerApp", ["pmaServices"]);

console.log("inside polygonmaanager")

polygonManagerApp.constant("pmaConstants", {
    // GLOBALPREFIX: $("meta[name=glblprefix]").attr("content"),
    page_status: abc,
    target_polygon: TempPolygon
});

polygonManagerApp.directive("toolButton", function factoryFn(stateService) {
    // the scope shoudl be scope of pmaDefaultCtrl
    return function linkFn(scope, element, attrs) {
        var targetStatus = attrs["targetStatus"];
        element.on("click", function (e) {
            stateService.setStatus(targetStatus !== stateService.getStatus() ? targetStatus : null);
        });
        scope.$watch(
          function (scope) {
              return stateService.getStatus() === targetStatus;
          },
          function (isActive, oldValue) {
              if (isActive) {
                  element.addClass("active");
              } else {
                  element.removeClass("active");
              }
          }
        );
    }
});

// pmaDefaultCtrl means "polygonManagerApp Default Controller"
polygonManagerApp.controller("pmaDefaultCtrl", function ($scope) {
    // some default javascript I put them here
    console.log("running block of default controller.");
});

// This one will be run first
polygonManagerApp.service("stateService", function ($rootScope) {
    console.log("running stateService singleton constructor callback");
    var ss = this;
    var panelStatusOptions = ["polygondrawing", "arearemoving", "shapeediting",
    "treatmentsetting", "productlisting", "resetting"];
    var panelStatus = null;
    ss.setStatus = function (toBeSetStatus) {
        console.log("toBe=" + toBeSetStatus);
        if (toBeSetStatus === null) {
            panelStatus = null;
            $rootScope.$applyAsync();  // changed from $apply() to $applyAsync()
            return;
        }
        toBeSetStatus = toBeSetStatus.toLowerCase();
        if (panelStatusOptions.indexOf(toBeSetStatus) < 0) {
            console.error("cannot set panel into status other statuses mentioned in panelStatusOptions array.");
            return;
        }
        panelStatus = toBeSetStatus;
        $rootScope.$apply();
        console.log("stateService._panelStatus: " + panelStatus);
        return;
    };
    ss.getStatus = function () {
        console.log("getStatus(): " + panelStatus);
        return panelStatus;
    };
});

polygonManagerApp.controller("pmaToolPanelCtrl",
  function (
    $scope, $rootScope,
    stateService, mapRelatedService,
    mapRelatedFunctionsService, pmaConstants) {
      console.log("loading pmaToolPanelCtrl.");
      /* $scope.myButton=true; */
      $scope.pmaConstants = pmaConstants;
      $scope.$watch(
        function () {
            //$scope.myButton=true
            return stateService.getStatus();
        },
        function (newStatus, oldStatus) {
            console.log("newstatus=" + newStatus);
            console.log(pmaConstants.page_status.isAuthenticated);
            console.log(typeof(pmaConstants.page_status.isAuthenticated));
            if (newStatus !== null && pmaConstants.page_status.isAuthenticated === false) {
               // alert("null");
                console.log("######");
                $('#signin-required-modal').modal("show"); // if user has not signed, he cannot use these function
                stateService.setStatus(null);
                return;
            }
            switch (oldStatus) {
                case "polygondrawing":
                    // status changed from polygondrawing to something else
                    mapRelatedFunctionsService.transformPolylineIntoPolygon(mapRelatedService, stateService);
                    break;
                case "arearemoving":
                    mapRelatedFunctionsService.transformPolylineIntoRemovedArea(mapRelatedService, stateService);
                    if (!mapRelatedService.activePolygon) {
                        // $scope.myButton=true;
                    }
                    break;

                case "shapeediting":
                    if (mapRelatedService.activePolygon) {
                        mapRelatedService.activePolygon.setEditable(false);
                    }
                    break;
                case "treatmentsetting":

                    break;
            }  // close switch (oldStatus)

            switch (newStatus) {
                case "polygondrawing":
                    
                    if (mapRelatedService.polygons.length >= 1) {
                        alert("Cannot create more than one polygon");
                        stateService.setStatus(null);

                        return;
                    }
                    break;
                case "arearemoving":
                    if (!mapRelatedService.isOnlyOnePolygon()) {
                        alert("can not remove area when there is NO active polygon on map.");
                        stateService.setStatus(null);

                        return;
                    }
                    break;
                case "shapeediting":
                    if (mapRelatedService.isOnlyOnePolygon()) {
                        mapRelatedService.activePolygon = mapRelatedService.polygons[0];
                    }
                    if (mapRelatedService.activePolygon) {
                        mapRelatedService.activePolygon.setEditable(true);
                    }
                    break;
                case "treatmentsetting":
                    if (mapRelatedService.isOnlyOnePolygon()) {
                        mapRelatedService.activePolygon = mapRelatedService.polygons[0];

                    }
                    if (mapRelatedService.activePolygon && mapRelatedService.isOnlyOnePolygon()) {

                        $rootScope.$broadcast('shouldOpenTreatment', {
                            content: "hehe"
                        });
                    }
                    break;
                case "productlisting":
                    if (mapRelatedService.isOnlyOnePolygon()) {
                        
                        mapRelatedService.activePolygon = mapRelatedService.polygons[0];
                    }
                    if (mapRelatedService.activePolygon) {
                       // set_treatment(polygon_id);
                        location.href = "/InteractiveLandscape/Treatment/" + polygon_id;; // TODO: add glblprefix to config of this application
                        
                    }
                    break;
                case "resetting":
                    mapRelatedFunctionsService.pmaReset(mapRelatedService, stateService);

                    break;
                default:
            }
        }
      );  // end of $watch();
      $scope.deleteGeojsonInPatchMode = function () {

          if (mapRelatedService.isOnlyOnePolygon()) {
              mapRelatedService.activePolygon = mapRelatedService.polygons[0];
          }
          console.log(mapRelatedService.activePolygon._id)
          if (confirm("You really want to delete this polygon ?")) {
              DeletePolygonFunction();
              //$.ajax({
              //    type: "DELETE",
              //    url: "/landscape/homeownermng/" + mapRelatedService.activePolygon._id,
              //    success: function (apiResult) {
              //        location.href = apiResult.jumpUrl;
              //    },
              //    error: function (jqXHR, textStatus, errorThrown) {
              //        location.alert("jhj" + textStatus);
              //    }
              //});
          }
      }

      // polylineFinishing event is triggerred at handlerFn of temp_startmarker.addListener('click', handlerFn)
      $scope.$on('polylineFinishing', function (event) {
          switch (stateService.getStatus()) {
              case "polygondrawing":
                  mapRelatedFunctionsService.transformPolylineIntoPolygon(mapRelatedService, stateService);
                  stateService.setStatus(null);
                  break;
              case "arearemoving":
                  mapRelatedFunctionsService.transformPolylineIntoRemovedArea(mapRelatedService, stateService);
                  break;
          }
      });
  });

polygonManagerApp.controller("pmaModalsCtrl", function ($scope, pmaConstants, stateService, mapRelatedService, mapRelatedFunctionsService) {
    console.log("pmaModalsCtrl init()");
    var $treatmentModal = $("#treatment-modal");
    //$scope.optionsForTypeOfUse = ["home", "professional", "agricultural"];
    $scope.optionsForTypeOfUse = [
     { value: "home", optionText: "Home" },
     { value: "professional", optionText: "Professional" },
     { value: "agricultural", optionText: "Agricultural" }
    ];
    $scope.optionsForControlMethod = [
      { value: "bait", optionText: "Bait and Sterilize Queen", explaination: "worker ants send product to queen. Queen eats and then unable to give birth to new ants" },
      { value: "contact", optionText: "Kill by Direct Contact", explaination: "When fire ants have been in contact with the ingredients of products, they are killed" },
      { value: "baitcontact", optionText: "Product that Can Do Both", explaination: "Product can do both 'bait' and 'contact'" }
    ];
    $scope.optionsForUsage = [
      { value: "broadcast", optionText: "Broadcast", explaination: "You want to focus on several fire ant mounds" },
      { value: "imt", optionText: "Individual Mound Treatment", explaination: "It is done mainly for preventive purpose" },
      { value: "broadcastimt", optionText: "Product that Can Do Both", explaination: "Product that can do both." }
    ];
    $scope.treatment = {
        polygon_name: null,  // required
        address: null,
        notes: null,

        // total_area, // will be filled at saveAndGenResult()
        mound_density: null,
        mound_number: null,

        type_of_use: null,         // required
        control_method: null,   // required
        usage: null,                // required
        is_outdoor: null,       // 
        need_organic: null,
        need_safe_for_pets: null,

        // environment_map: null,  // this field will be filled by underlying JS logic
        // bounds,         // this field will be filled by underlying JS logic
        owner: null,         // this field will be filled by JS logic
    };

    $scope.$watch(
      function ($scope) {
          return $scope.treatment.usage;
      },
      function (newValue, oldValue) {
          if (oldValue === "imt") {
              $scope.treatment.mound_number = null;
          }
      }
    );

    $scope.openTreatmentModal = function () {

        $treatmentModal.modal('show');
    };

    // user clicked 'x' of Treatment modal
    $scope.mergeTreatmentAndRender = function () {
        // no need to hide modal, since 'x' has data-dismiss attribute
        if (mapRelatedService.isOnlyOnePolygon()) {
            stateService.setStatus(null);
        }
        if (!mapRelatedService.activePolygon) {
            console.error("mergeTreatAndRender() did not find activePolygon");
            return;
        }
        var activePolygon = mapRelatedService.activePolygon;
        if (!angular.isDefined(activePolygon.properties)) {
            activePolygon.properties = {};
        }
        angular.extend(activePolygon.properties, $scope.treatment);
        mapRelatedFunctionsService.renderPolygonProperly(activePolygon, mapRelatedService);
    }

    // user clicked 
    $scope.saveTreatmentAndPolygonToServer = function ($event) {
        //alert("save")
        var abc = { model_op: "patch", isAuthenticated: false };
        console.log(abc);
        polygonManagerApp.constant("pmaConstants", {
            // GLOBALPREFIX: $("meta[name=glblprefix]").attr("content"),
            page_status: abc
        });
        console.log("save treatment to server.");
        console.log($event);
        var $targetButton = $($event.target);
        $targetButton.text("Submitting...");
        $targetButton.addClass("disabled");
        // return;
        var geoJsonPolygon = mapRelatedFunctionsService.saveAndGenResult(
          mapRelatedService.activePolygon,
          mapRelatedService
        );
        angular.extend(geoJsonPolygon.properties, $scope.treatment);
        console.log(JSON.stringify(geoJsonPolygon));
        

        // return;
        $("input#geojson").val(JSON.stringify(geoJsonPolygon));
        var $tempForm = $('form#treatment');
        console.log($tempForm.attr('action'))
        SavePolygonFunction(geoJsonPolygon);
        

        // $treatmentModal.modal('hide');
        // if (mapRelatedService.isOnlyOnePolygon()) {
        //   stateService.setStatus(null);
        // }
        // mapRelatedFunctionsService.renderPolygonProperly(mapRelatedService.activePolygon, mapRelatedService);
    };

    $scope.fillTreatmentForm = function (googleMVCObjectPolygon) {  //TODO
        console.log("I am going to fill the form");
        console.log(googleMVCObjectPolygon.properties);
        angular.forEach($scope.treatment, function (value, keyName) {
            if (angular.isDefined(googleMVCObjectPolygon.properties[keyName])) {
                $scope.treatment[keyName] = angular.copy(googleMVCObjectPolygon.properties[keyName]);
            }
        });
    };

    // shouldOpenTreatment event is broadcasted at two places:
    // (1) TODO: to write comment here
    // (2) TODO: to wirte comment here
    $scope.$on('shouldOpenTreatment', function (event, args) {
        $scope.openTreatmentModal();
    });

    //fillTreatmentForm event will be broadcasted at pmaServices.run callback
    $scope.$on('fillTreatmentForm', function (event, args) {
        $scope.fillTreatmentForm(args.targetPolygon);
    });
});