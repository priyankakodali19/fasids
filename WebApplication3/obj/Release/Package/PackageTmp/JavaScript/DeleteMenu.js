/**
 * https://developers.google.com/maps/documentation/javascript/examples/delete-vertex-menu?hl=en
 * A menu that lets a user delete a selected vertex of a path.
 * @constructor
 */
function DeleteMenu() {
    this.div_ = document.createElement('div');
    this.div_.className = 'delete-menu';
    this.div_.innerHTML = '<ul class="list-unstyled"><li id="li-delete-vertex">Delete Vertex</li><li id="li-delete-sub-route">Delete Sub Route</li></ul>';
    this.target_polygon_ = null;
    this.jQuery_div_ = $(this.div_);  // create one jQuery_div_

    this.delete_vertex_li_ = this.jQuery_div_.find("#li-delete-vertex").get(0);
    this.delete_sub_route_li_ = this.jQuery_div_.find("#li-delete-sub-route").get(0);

    var menu = this;
    // this.jQuery_div_.find("#li-delete-vertex").click(function (e){
    //   alert("delete vertex");
    // })
    google.maps.event.addDomListener(this.delete_vertex_li_, 'click', function (e) {
        menu.removeVertex();
        // alert("delete vertex");
    });
    google.maps.event.addDomListener(this.delete_sub_route_li_, 'click', function (e) {
        menu.removePath();
        // alert("delete subroute");
    });
}
DeleteMenu.prototype.setTargetPolygon = function (googleMapMVCPolygon) {
    if (!googleMapMVCPolygon) {
        throw "googleMapMVCPolygon cannot be falsy value";
        return;
    }

}

DeleteMenu.prototype = new google.maps.OverlayView();

DeleteMenu.prototype.onAdd = function () {
    // console.log("onAdd()");
    var deleteMenu = this;
    var map = this.getMap();
    this.getPanes().floatPane.appendChild(this.div_);
    // mousedown anywhere on the map except on the menu div will close the menu.
    this.divListener_ = google.maps.event.addDomListener(map.getDiv(), 'mousedown', function (e) {
        if (deleteMenu.jQuery_div_.find(e.target).length === 0 && e.target != deleteMenu.div_) {
            // console.log("deleteMenu.close()");
            deleteMenu.close();
        }
    }, true);
};

DeleteMenu.prototype.onRemove = function () {
    // console.log("onRemove()")
    google.maps.event.removeListener(this.divListener_);
    this.div_.parentNode.removeChild(this.div_);
    // clean up
    this.set('position');
    this.set('path');
    this.set('vertex');
};

DeleteMenu.prototype.close = function () {
    // console.log("close()");
    this.setMap(null);
};

DeleteMenu.prototype.draw = function () {
    var position = this.get('position');
    var projection = this.getProjection();
    if (!position || !projection) {
        return;
    }
    var point = projection.fromLatLngToDivPixel(position);
    this.div_.style.top = point.y + 'px';
    this.div_.style.left = point.x + 'px';
};

/**
 * Opens the menu at a vertex of a given path.
 */
DeleteMenu.prototype.open = function (map, path, vertex, activePolygon) {
    // console.log( "path lenght : " + path.getLength());
    this.target_polygon_ = activePolygon;
    this.set('position', path.getAt(vertex));
    this.set('path', path);
    this.set('vertex', vertex);
    this.setMap(map);
    this.draw();
};

/**
 * Deletes the vertex from the path.
 */
DeleteMenu.prototype.removeVertex = function () {
    var path = this.get('path');  // path is actually one instance of MVCArray class which extends MVCObject
    var vertex = this.get('vertex');
    if (!path || vertex == undefined) {
        this.close();
        return;
    }

    if (path.getLength() > 3) {
        path.removeAt(vertex);
    } else {
        alert("Cannot remove one more vertex from a polygon with 3 vertice");
    }
    this.close();
};

/**
* Delete this path from Polygon
*/
DeleteMenu.prototype.removePath = function () {
    var target_path = this.get('path');  // inherited method of overlayView
    var target_polygon = this.target_polygon_;
    if (!target_polygon) {
        console.error("did not find target_polygon_");
        this.close();
        return;
    }
    var polygon_paths = target_polygon.getPaths();
    if (polygon_paths.getLength() < 2) {
        alert("This polygon does not contain subroute(s), and cannot use this method to remove exterior path.");
        this.close();
        return;
    }
    polygon_paths.forEach(function (path, index, ar) {
        if (path === target_path) {   // reference comparison
            polygon_paths.removeAt(index);
        }
    });
    this.close();
}
