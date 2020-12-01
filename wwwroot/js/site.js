// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    GetMap();
    var search_btn = document.getElementById('search_btn');
    search_btn.addEventListener('click', onSearch)
});

function onSearch() {
    var search_inp = document.getElementById('search_inp');
    var osm = document.getElementById('osm-map');
    if (osm == null || search_btn.nodeValue==null) { return; }
    getAllDots(L.map(osm), search_inp.nodeValue);
}
// Функция загрузки карты
function GetMap() {
    // Where you want to render the map.
    var osm = document.getElementById('osm-map');
    if (osm == null) { return;}
    // Height has to be set. You can do this in CSS too.
    osm.style = 'height:600px;';
    osm.style.cursor = 'crosshair';

    // Create Leaflet map on map element.
    var map = L.map(osm);
    setDotCoord(map);

    // Add OSM tile leayer to the Leaflet map.
    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    getAllDots(map);

    // Target's GPS coordinates.
    var target = L.latLng('47.09594298223346', '37.549585103988655');

    // Set map's center to target with zoom 14.
    map.setView(target, 16);

    // Place a marker on the same location.
    //L.marker(target).addTo(map);
}
function setDotCoord(map) {
    map.on('contextmenu', (e) => {
        var LatLng = { Latitude: e.latlng.lat, Longitude: e.latlng.lng };
        let json = JSON.stringify(LatLng);
        var actionUrl = '/Home/SetDot?data=' + encodeURIComponent(json);
        L.popup()
            .setLatLng(e.latlng)
            .setContent('<a href="' + actionUrl +'" type="application/json" class="ui-btn ui-corner-all" >Добавить точку на карту</a>')
            .openOn(map);
    });
}
function getAllDots(map, search="") {
    var dataUrl = '/Home/GetData';

    $.ajax({
        type: 'POST',
        dataType: 'json',
        cache: false,
        url: dataUrl,
        data: { text: search},
        success: function (dots, textStatus, jqXHR) {
            var container = document.getElementById('dot-list');
            container.innerHTML = '';
            var base_url = window.location.origin+"/";
            for (var i = 0; i < dots.length; i++) {
                var d = dots[i];
                d.thumb_file = base_url + d.thumb_file;
                var target = L.latLng(d.latitude, d.longitude);
                var icon = L.icon({
                    iconUrl: d.thumb_file,
                    iconSize: [40, 40]
                });

                var opts = {
                    icon: icon,
                    dot: d
                };
                var marker = L.marker(target, opts);
                
                marker.addTo(map);
                var elem = document.createElement("button");
                elem.textContent = d.title;
                elem.classList.add('row', 'btn', 'btn-primary');
                container.appendChild(elem);

                marker.on("click", function (e) {
                    L.popup()
                        .setLatLng(e.latlng)
                        .setContent(popupContent(e.sourceTarget.options.dot))
                        .openOn(map);
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Error - ' + errorThrown);
        }
    });
}
function popupContent(d) {
    let json = JSON.stringify(d.id);
    var editUrl = '/Home/EditDot?id=' + encodeURIComponent(json);
    var content = 
        '<h2>' + d.title + '</h2>' +
        '<div>' + d.description + '</div>' +
        '<a href="tel:' + d.phone + '" >Позвонить</a>' +
        '<br>'+
        '<a href="mailto:' + d.email + '" >Написать на почту</a>' +
        '<div><img src="' + d.thumb_file + '" width="200" height="200" alt="image"></div>' +
    '<a href="' + editUrl + '" type="application/json" class="ui-btn ui-corner-all" >Изменить</a>'
    ;
    return content;
}

class Dot {
    id;
    user;
    phone;
    email;
    category;
    city;
    title;
    description;
    thumbName;
    thumbFile;
    timeOpen;
    timeClose;
    website;
    latitude;
    longitude;
}