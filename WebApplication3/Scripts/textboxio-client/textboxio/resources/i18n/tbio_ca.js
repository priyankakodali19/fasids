/** @license
 * Copyright (c) 2013-2017 Ephox Corp. All rights reserved.
 * This software is provided "AS IS," without a warranty of any kind.
 */
!function(){var a=function(){return{a11y:{widget:{title:"Comprovaci\xf3 d'accessibilitat",running:"Comprovant...",issue:{counter:"Problema {0} de {1}",help:"Refer\xe8ncia WCAG 2.0 - s'obre en una finestra nova",none:"No s'han detectat problemes d'accessibilitat"},previous:"Problema anterior",next:"Problema seg\xfcent",repair:"Reparar problema",available:"Reparaci\xf3 disponible",ignore:"Ignorar"},image:{alttext:{empty:"Les imatges han de tenir una descripci\xf3 de text alternativa",filenameduplicate:"El text alternatiu no pot ser el mateix que el nom de fitxer de la imatge",set:"Introdu\xefu un text alternatiu:",validation:{empty:"El text alternatiu no pot estar buit",filenameduplicate:"El text alternatiu no pot ser el mateix que el nom de fitxer"}}},table:{caption:{empty:"Les taules han de tenir llegendes",summaryduplicate:"El resum i la llegenda de la taula no poden tenir el mateix valor",set:"Introdu\xefu una llegenda:",validation:{empty:"La llegenda no pot estar buida",summaryduplicate:"La llegenda de la taula no pot ser la mateixa que el resum de la taula"}},summary:{empty:"Les taules complexes han de tenir resums",set:"Introdu\xefu el resum de la taula:",validation:{empty:"El resum de la taula no pot estar buit",captionduplicate:"El resum de la taula no pot ser el mateix que la llegenda de la taula"}},rowscells:{none:"Els elements de la taula han de contenir etiquetes TR i TD"},headers:{none:"Les taules han de tenir almenys una cel\xb7la de cap\xe7alera",set:"Seleccioneu la cap\xe7alera de la taula:",validation:{none:"Seleccioneu la cap\xe7alera de fila o cap\xe7alera de columna"}},headerscope:{none:"Les cap\xe7aleres de taula s'han d'aplicar a una fila o a una columna",set:"Seleccioneu l'\xe0mbit de cap\xe7alera:",scope:{row:"Fila",col:"Columna",rowgroup:"Grup de files",colgroup:"Grup de columnes"}}},heading:{nonsequential:"Els encap\xe7alaments s'han d'aplicar de forma consecutiva. Per exemple: l'encap\xe7alament 1 ha d'estar seguit per l'encap\xe7alament 2, no per l'encap\xe7alament 3.",paragraphmisuse:"Aquest par\xe0graf sembla un encap\xe7alament. Si \xe9s un encap\xe7alament, seleccioneu un nivell d'encap\xe7alament.",set:"Seleccioneu un nivell d'encap\xe7alament:"},link:{adjacent:"Els enlla\xe7os adjacents amb la mateixa URL s'haurien de combinar en un enlla\xe7"},list:{paragraphmisuse:"Sembla que el text seleccionat \xe9s una llista. Les llistes s'han de formatar amb una etiqueta de llista."},contrast:{smalltext:"El text ha de tenir una relaci\xf3 de contrast de com a m\xednim 4.5:1",largetext:"El text de mida gran ha de tenir una relaci\xf3 de contrast de com a m\xednim 3:1"},severity:{error:"Error",warning:"Advert\xe8ncia",info:"Informaci\xf3"}},aria:{autocorrect:{announce:"Correcci\xf3 autom\xe0tica {0}"},label:{toolbar:"Barra d'eines editor de text enriquit",editor:"Editor de text enriquit Textbox.io - {0}",fullscreen:"Editor de text enriquit de pantalla completa Textbox.io - {0}",content:"Contingut editable",more:"Feu clic per expandir o reduir"},help:{mac:"Premeu \u2303\u2325H per rebre ajuda",ctrl:"Premeu CTRL MAJ H per rebre ajuda"},color:{picker:"Selector de colors",menu:"Men\xfa del selector de colors"},font:{color:"Colors del text",highlight:"Colors de l'ombrejat",palette:"Paleta de colors"},context:{menu:{generic:"Men\xfa de context"}},stepper:{input:{invalid:"El valor de mida no \xe9s v\xe0lid"}},table:{headerdescription:"Premeu la barra espaiadora per activar la configuraci\xf3. Premeu la tecla de tabulaci\xf3 per tornar al selector de taula.",cell:{border:{size:"Mida de la vora"}}},input:{invalid:"Les dades no s\xf3n v\xe0lides"},widget:{navigation:"Utilitzeu les tecles de fletxa per navegar."},image:{crop:{size:"La mida d'escap\xe7ament \xe9s de {0} p\xedxel(s) per {1} p\xedxel(s)"}}},color:{white:"Blanc",black:"Negre",gray:"Gris",metal:"Metall",smoke:"Opac",red:"Vermell",darkred:"Vermell fosc",darkorange:"Taronja fosc",orange:"Taronja",yellow:"Groc",green:"Verd",darkgreen:"Verd fosc",mediumseagreen:"Verd aigua",lightgreen:"Verd clar",lime:"Llima",mediumblue:"Blau mitj\xe0",navy:"Blau mar\xed",blue:"Blau",lightblue:"Blau clar",violet:"Lila"},directionality:{rtldir:"Direcci\xf3 de dreta a esquerra",ltrdir:"Direcci\xf3 d'esquerra a dreta"},parlance:{menu:"Men\xfa d'idioma",set:"Definir idioma",ar:"\xc0rab",ca:"Catal\xe0",zh_cn:"Xin\xe8s (Simplificat)",zh_tw:"Xin\xe8s (Tradicional)",hr:"Croat",cs:"Txec",da:"Dan\xe8s",nl:"Neerland\xe8s",en:"Angl\xe8s",en_au:"Angl\xe8s (Austr\xe0lia)",en_ca:"Angl\xe8s (Canad\xe0)",en_gb:"Angl\xe8s (Regne Unit)",en_us:"Angl\xe8s (Estats Units)",fa:"Persa",fi:"Fin\xe8s",fr:"Franc\xe8s",fr_ca:"Franc\xe8s (Canad\xe0)",de:"Alemany",el:"Grec",he:"Hebreu",hu:"Hongar\xe8s",it:"Itali\xe0",ja:"Japon\xe8s",kk:"Kazakh",ko:"Core\xe0",no:"Noruec",pl:"Polon\xe8s",pt_br:"Portugu\xe8s (Brasil)",pt_pt:"Portugu\xe8s (Portugal)",ro:"Roman\xe8s",ru:"Rus",sk:"Eslovac",sl:"Eslov\xe8",es:"Espanyol",es_419:"Espanyol (Am\xe8rica Llatina)",es_es:"Espanyol (Espanya)",sv:"Suec",tt:"T\xe0tar",th:"Tailand\xe8s",tr:"Turc",uk:"Ucra\xefn\xe8s"},taptoedit:"Toqueu per editar",plaincode:{dialog:{title:"Visualitzaci\xf3 de codi",editor:"Editor de font HTML"}},help:{dialog:{accessibility:"Navegaci\xf3 amb el teclat",a11ycheck:"Comprovaci\xf3 d'accessibilitat",about:"Sobre Textbox.io",markdown:"Format Markdown",shortcuts:"Dreceres de teclat"}},spelling:{context:{more:"M\xe9s",morelabel:"Submen\xfa altres opcions d'ortografia"},none:"Cap",menu:"Idioma d'ortografia"},specialchar:{open:"Car\xe0cter especial",dialog:"Inserir car\xe0cter especial",latin:"Llat\xed",insert:"Insereix",punctuation:"Puntuaci\xf3",currency:"Monedes","extended-latin-a":"Llat\xed ext\xe8s A","extended-latin-b":"Llat\xed ext\xe8s B",arrows:"Fletxes",mathematical:"S\xedmbols matem\xe0tics",miscellaneous:"Diversa",selects:"Car\xe0cters seleccionats",grid:"Car\xe0cters especials"},insert:{"menu-button":"Men\xfa d'inserci\xf3",menu:"Insereix",link:"Enlla\xe7",image:"Imatge",table:"Taula",horizontalrule:"Regle horitzontal",media:"Multim\xe8dia"},media:{embed:"Codi d'incrustaci\xf3 d'elements multim\xe8dia",insert:"Insereix",placeholder:"Enganxeu el codi d'incrustaci\xf3 aqu\xed."},wordcount:{open:"Recompte de paraules",dialog:"Recompte de paraules",counts:"Recompte",selection:"Selecci\xf3",document:"Document",characters:"Car\xe0cters",charactersnospaces:"Car\xe0cters (sense espais)",words:"Paraules"},list:{unordered:{menu:"Opcions de llista sense ordenar",default:"Desordenat per defecte",circle:"Desordenat per cercle",square:"Desordenat per quadre",disc:"Desordenat per disc"},ordered:{menu:"Opcions de llista ordenada",default:"Ordenat per defecte",decimal:"Ordenat per decimal","upper-alpha":"Ordenat per lletra maj\xfascula","lower-alpha":"Ordenat per lletra min\xfascula","upper-roman":"Ordenat per car\xe0cters romans en maj\xfascula","lower-roman":"Ordenat per car\xe0cters romans en min\xfascula","lower-greek":"Ordenat per car\xe0cters grecs en min\xfascula"}},tag:{inline:{class:"span ({0})"},img:"imatge"},block:{normal:"Normal",p:"Par\xe0graf",h1:"Encap\xe7alament 1",h2:"Encap\xe7alament 2",h3:"Encap\xe7alament 3",h4:"Encap\xe7alament 4",h5:"Encap\xe7alament 5",h6:"Encap\xe7alament 6",div:"Div",pre:"Pre",li:"Element de la llista",td:"Cel\xb7la",th:"Cel\xb7la de cap\xe7alera",styles:"Men\xfa d'estils",dropdown:"Blocs",describe:"Estil actual {0}",menu:"Estils",label:{inline:"Estils en l\xednia",table:"Estils de taula",line:"Estils de l\xednia",media:"Estils d'elements multim\xe8dia",list:"Estils de llista",link:"Estils d'enlla\xe7"}},font:{"menu-button":"Men\xfa de tipus de lletra",menu:"Tipus de lletra",face:"Tipografia",size:"Mida del tipus de lletra",coloroption:"Color",describe:"Tipus de lletra actual {0}",color:"Text",highlight:"Marca",stepper:{input:"Defineix la mida de lletra",increase:"Augmentar la mida de lletra",decrease:"Reduir la mida de lletra"}},cog:{"menu-button":"Men\xfa de configuraci\xf3",menu:"Configuraci\xf3",spellcheck:"Corrector ortogr\xe0fic",capitalisation:"\xdas de maj\xfascules",autocorrect:"Correcci\xf3 autom\xe0tica",linkpreviews:"Visualitzacions pr\xe8vies de l'enlla\xe7",help:"Ajuda"},alignment:{toolbar:"Men\xfa d'alineaci\xf3",menu:"Alineaci\xf3",left:"Alinea a l'esquerra",center:"Alinea al centre",right:"Alinea a la dreta",justify:"Justifica",describe:"Alineaci\xf3 actual {0}"},category:{language:"Grup d'idioma",undo:"Grup de desfer i refer",insert:"Grup d'inserci\xf3",style:"Grup d'estils",emphasis:"Grup de format",align:"Grup d'alineaci\xf3",listindent:"Grup de llista i sagnat",format:"Grup de tipus de lletra",tools:"Grup d'eines",table:"Grup de taules",image:"Grup d'edici\xf3 d'imatges"},action:{undo:"Desf\xe9s",redo:"Ref\xe9s",bold:"Negreta",italic:"Cursiva",underline:"Subratllat",strikethrough:"Barrat",subscript:"Sub\xedndex",superscript:"Super\xedndex",removeformat:"Elimina el format",bullist:"Llista sense ordenar",numlist:"Llista ordenada",indent:"Sagna m\xe9s",outdent:"Sagna menys",blockquote:"Blockquote",fullscreen:"Pantalla sencera",search:"Di\xe0leg de cerca i reempla\xe7a",a11ycheck:"Comprovar accessibilitat",toggle:{fullscreen:"Sortir del mode de pantalla sencera"}},table:{menu:"Insereix taula","column-header":"Columna de cap\xe7alera","row-header":"Fila de cap\xe7alera",float:"Alineaci\xf3 flotant",cell:{color:{border:"Color de la vora",background:"Color de fons"},border:{width:"Amplada de la vora",stepper:{input:"Definir l'amplada de la vora",increase:"Augmentar l'amplada de la vora",decrease:"Reduir l'amplada de la vora"}}},context:{row:{title:"Submen\xfa de fila",menu:"Fila",insertabove:"Insereix a dalt",insertbelow:"Insereix a baix"},column:{title:"Submen\xfa de columna",menu:"Columna",insertleft:"Insereix a l'esquerra",insertright:"Insereix a la dreta"},cell:{merge:"Combina cel\xb7les",unmerge:"Separa les cel\xb7les"},table:{title:"Submen\xfa de taula",menu:"Taula",properties:"Propietats",delete:"Suprimeix"},common:{delete:"Suprimeix",normal:"Defineix com a Normal",header:"Defineix com a Cap\xe7alera"},palette:{show:"Les opcions d'edici\xf3 de taula estan disponibles a la barra d'eines",hide:"Les opcions d'edici\xf3 de taula ja no estan disponibles"}},picker:{header:"S'ha definit la cap\xe7alera",label:"Selector de taula",describepicker:"Utilitzeu les tecles de fletxa per definir la mida de la taula.  Premeu la tecla de tabulaci\xf3 per accedir a la configuraci\xf3 de la cap\xe7alera de la taula. Premeu la tecla espai o la tecla retorn per inserir la taula.",rows:"{0} alt",cols:"{0} ample"},border:"Vora",summary:"Resum",dialog:"Propietats de la taula",caption:"Llegenda de la taula",width:"Amplada",height:"Al\xe7ada"},align:{none:"Cap alineaci\xf3",center:"Alinea al centre",left:"Alinea a l'esquerra",right:"Alinea a la dreta"},button:{ok:"D'acord",cancel:"Cancel\xb7la",close:"Di\xe0leg de cancel\xb7laci\xf3"},banner:{close:"Tancar b\xe0nner"},border:{on:"Activat",off:"Desactivat",labels:{on:"Afegeix vora",off:"Treu vora"}},loading:{wait:"Espereu-vos..."},toolbar:{more:"M\xe9s",backbutton:"Enrere","switch-code":"Canvia a Visualitzaci\xf3 de codi","switch-pencil":"Canvia a Visualitzaci\xf3 de disseny"},link:{context:{edit:"Edita l'enlla\xe7",follow:"Obre l'enlla\xe7",ignore:"Ignora l'enlla\xe7 trencat",remove:"Suprimeix l'enlla\xe7"},dialog:{aria:{update:"Actualitza l'enlla\xe7",insert:"Insereix un enlla\xe7",properties:"Propietats de l'enlla\xe7",quick:"Opcions r\xe0pides"},autocomplete:{open:"Enlla\xe7 a la llista d'emplenament autom\xe0tic disponible. Continueu escrivint o utilitzeu les fletxes cap amunt i cap avall per seleccionar suggeriments.",close:"Enlla\xe7 a la llista d'emplenament autom\xe0tic tancat",accept:"Suggeriment de l'enlla\xe7 seleccionat {0}"},edit:"Edita",remove:"Suprimeix",preview:"Visualitzaci\xf3 pr\xe8via",update:"Actualitza",insert:"Insereix",tooltip:"Enlla\xe7"},properties:{dialog:{title:"Propietats de l'enlla\xe7"},text:{label:"Text per visualitzar",placeholder:"Introdu\xefu o enganxeu text per visualitzar"},url:{label:"URL de l'enlla\xe7",placeholder:"Introdu\xefu o enganxeu URL"},title:{label:"T\xedtol",placeholder:"Introdu\xefu o enganxeu t\xedtol de l'enlla\xe7"},button:{remove:"Suprimeix"},target:{label:"Destinaci\xf3",none:"Cap",blank:"Nova finestra",top:"P\xe0gina sencera",self:"Mateix marc",parent:"Marc principal"}},anchor:{top:"Part superior del document",bottom:"Part inferior del document"}},fileupload:{title:"Insereix Imatges",tablocal:"Fitxers locals",tabweburl:"URL del web",dropimages:"Deixeu anar les imatges aqu\xed",chooseimage:"Trieu la imatge que voleu carregar",web:{url:"Imatge web URL:"},weburlhelp:"Introdu\xefu la vostra URL per veure una visualitzaci\xf3 pr\xe8via de la imatge. \xc9s possible que les imatges grans triguin a apar\xe8ixer.",invalid1:"No hem trobat cap imatge a l'URL que esteu utilitzant.",invalid2:"Assegureu-vos d'haver escrit l'URL correctament.",invalid3:"Assegureu-vos que la imatge a la qual voleu accedir \xe9s p\xfablica i que no est\xe0 protegida amb una contrasenya o en una xarxa privada."},image:{context:{properties:"Propietats de la imatge",palette:{show:"Les opcions d'edici\xf3 d'imatge estan disponibles a la barra d'eines",hide:"Les opcions d'edici\xf3 d'imatge ja no estan disponibles"}},dialog:{title:"Propietats de la imatge",fields:{align:"Alineaci\xf3 flotant",url:"Direcci\xf3 URL",urllocal:"La imatge encara no s'ha desat",alt:"Text alternatiu",width:"Amplada",height:"Al\xe7ada",constrain:{label:"Restringir proporcions",on:"Proporcions bloquejades",off:"Proporcions desbloquejades"}}},menu:"Insereix imatge","menu-button":"Insereix men\xfa d'imatge","from-url":"URL del web","from-camera":"Carret",toolbar:{rotateleft:"Girar a l'esquerra",rotateright:"Girar a la dreta",fliphorizontal:"Voltejar horitzontalment",flipvertical:"Voltejar verticalment",properties:"Propietats de la imatge"},crop:{announce:"Entrar a la interf\xedcie d'escap\xe7ament Premeu la tecla retorn per acceptar i la tecla escapament per cancel\xb7lar.",cancel:"Cancel\xb7lar l'operaci\xf3 d'escap\xe7ament",begin:"Escap\xe7ar la imatge",apply:"Aplicar escap\xe7ament",handle:{nw:"Control d'escap\xe7ament del cant\xf3 superior esquerre",ne:"Control d'escap\xe7ament de cant\xf3 superior dret",se:"Control d'escap\xe7ament de cant\xf3 inferior dret",sw:"Control d'escap\xe7ament de cant\xf3 inferior esquerre",shade:"M\xe0scara d'escap\xe7ament"}}},units:{"amount-of-total":"{0} de {1}"},search:{menu:"Cerca i reempla\xe7a",field:{replace:"Camp de reempla\xe7ament",search:"Camp de cerca"},search:"Cerca",previous:"Anterior",next:"Seg\xfcent",replace:"Reempla\xe7a","replace-all":"Reempla\xe7a totes",matchcase:"Fes coincidir maj\xfascules i min\xfascules"},mentions:{initiated:"Menci\xf3 creada, continua escrivint per a mem\xf2ria interm\xe8dia de teclat",lookahead:{open:"Quadre de llista de mem\xf2ria interm\xe8dia de teclat",cancelled:"Menci\xf3 cancel\xb7lada",searching:"S'estan cercant resultats",selected:"Menci\xf3 de {0} inserida",noresults:"No s'han trobat resultats"}},cement:{dialog:{paste:{title:"Opcions per enganxar el format",instructions:"Trieu si voleu conservar o eliminar el format al contingut enganxat",merge:"Conserva el format",clean:"Elimina el format"},flash:{title:"Importaci\xf3 d'imatges locals","trigger-paste":"Activeu l'eina torna a enganxar del teclat per enganxar contingut amb imatges.",missing:'\xc9s necessari l\'Adobe Flash per importar imatges de Microsoft Office. Instal\xb7leu l\'<a href="http://get.adobe.com/flashplayer/" target="_blank">Adobe Flash Player</a>.',"press-escape":'Premeu <span class="ephox-polish-help-kbd">ESC</span> per ignorar les imatges locals i continuar amb l\'edici\xf3.'}}},cloud:{error:{apikey:"La vostra clau API no \xe9s v\xe0lida.",domain:"El domini ({0}) no \xe9s compatible amb la vostra clau API.",plan:"Heu superat el nombre de desc\xe0rregues de l'editor disponibles al vostre pla. Visiteu el lloc web per actualitzar."},dashboard:"Aneu al tauler d'administraci\xf3"},errors:{paste:{notready:"La funci\xf3 d'importaci\xf3 de paraules no s'ha carregat. Espereu-vos i torneu-ho a provar.",generic:"S'ha produ\xeft un error mentre s'enganxava el contingut."},toolbar:{missing:{custom:{string:'Les ordres personalitzades han de tenir la propietat "{0}" i ha de ser una cadena'}},invalid:"La configuraci\xf3 per a la barra d'eines no \xe9s v\xe0lida ({0}). Vegeu la consola per obtenir m\xe9s detalls."},spelling:{missing:{service:"L'eina d'ortografia no es troba disponible: ({0})."}},images:{edit:{needsproxy:"Es necessita un proxy per editar imatges d'aquest domini: ({0})",proxyerror:"No s'ha pogut establir la comunicaci\xf3 amb el proxy per editar aquesta imatge. Vegeu la consola per obtenir m\xe9s detalls.",generic:"S'ha produ\xeft un error mentre s'aplicava l'operaci\xf3 d'edici\xf3 d'imatge. Vegeu la consola per obtenir m\xe9s detalls."},disallowed:{local:"L'opci\xf3 d'enganxar imatges locals s'ha desactivat. Les imatges locals s'han eliminat del contingut enganxat.",dragdrop:"L'opci\xf3 d'arrossegar i col\xb7locar s'ha desactivat."},upload:{unknown:"La imatge no s'ha pogut carregar.",invalid:"No s'han processat tots els fitxers - alguns no eren imatges v\xe0lides",failed:"La imatge no s'ha pogut carregar: ({0}).",cors:"No s'ha pogut connectar amb el servei de c\xe0rrega d'imatges. Pot ser que s'hagi produ\xeft un error CORS: ({0})"},missing:{service:"No s'ha trobat el servei d'imatges: ({0}).",flash:"\xc9s possible que la configuraci\xf3 de seguretat del navegador impedeixi la importaci\xf3 d'imatges."},import:{failed:"Algunes imatges no s'han importat correctament.",unsupported:"Format d'imatge incompatible.",invalid:"La imatge no \xe9s v\xe0lida."}},webview:{image:"Les imatges copiades directament no es poden enganxar."},safari:{image:"Safari no permet enganxar imatges directament.",url:"M\xe9s informaci\xf3 sobre com enganxar imatges a Safari",rtf:"M\xe9s informaci\xf3 sobre l'eina enganxar a Safari"},flash:{crashed:"Les imatges no s'han pogut importar, ja que sembla que l'Adobe Flash ha fallat. \xc9s possible que aix\xf2 sigui a causa d'enganxar documents grans."},http:{400:"Sol\xb7licitud incorrecta: {0}",401:"No autoritzat: {0}",403:"Acc\xe9s prohibit: {0}",404:"No trobat: {0}",407:"El servidor intermediari requereix autenticaci\xf3: {0}",409:"Fitxer en conflicte: {0}",413:"C\xe0rrega massa gran: {0}",415:"El tipus de fitxer multim\xe8dia no \xe9s suportat: {0}",500:"Error intern del servidor: {0}",501:"No implementat: {0}"}}}},b=function(a,b){var c=a.src.indexOf("?");return a.src.indexOf(b)+b.length===c},c=function(a){for(var b=a.split("."),c=window,d=0;d<b.length&&void 0!==c&&null!==c;++d)c=c[b[d]];return c},d=function(a,b){if(a){var d="data-main",e=a.getAttribute(d);if(e){a.removeAttribute(d);var f=c(e);if("function"==typeof f)return f;console.warn("attribute on "+b+" does not reference a global method")}else console.warn("no data-main attribute found on "+b+" script tag")}},e=function(a,c){var e=d(document.currentScript,c);if(e)return e;for(var f=document.getElementsByTagName("script"),g=0;g<f.length;g++)if(b(f[g],a)){var h=d(f[g],c);if(h)return h}throw"cannot locate "+c+" script tag"},f="2.1.0",g=e("tbio_ca.js","strings for language ca");g({version:f,strings:a})}();