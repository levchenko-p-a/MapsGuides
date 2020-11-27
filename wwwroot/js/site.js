// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    GetMap();
});

// Функция загрузки карты
function GetMap() {
    // Where you want to render the map.
    var element = document.getElementById('osm-map');
    if (element == null) { return;}
    // Height has to be set. You can do this in CSS too.
    element.style = 'height:600px;';
    element.style.cursor = 'crosshair';

    // Create Leaflet map on map element.
    var map = L.map(element);
    setDotCoord(map);

    // Add OSM tile leayer to the Leaflet map.
    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    getAllDots(map);

    // Target's GPS coordinates.
    var target = L.latLng('47.09594298223346', '37.549585103988655');

    // Set map's center to target with zoom 14.
    map.setView(target, 14);

    // Place a marker on the same location.
    L.marker(target).addTo(map);
}
function setDotCoord(map) {
    map.on('contextmenu', (e) => {
        var LatLng = { Latitude: e.latlng.lat, Longitude: e.latlng.lng };
        let json = JSON.stringify(LatLng);
        var actionUrl = '/Home/SetDot?data=' + encodeURIComponent(json);
        L.popup()
            .setLatLng(e.latlng)
            .setContent('<a href="' + actionUrl +'" type="application/json" class="ui-btn ui-corner-all" >Add point to map</a>')
            .openOn(map);
    });
}
function getAllDots(map) {
    var actionUrl = '/Home/GetData';

    $.ajax({
        type: 'POST',
        dataType: 'json',
        cache: false,
        url: actionUrl,
        success: function (dots, textStatus, jqXHR) {
            var container = document.getElementById('dot-list');
            container.innerHTML = '';
            for (var i = 0; i < dots.length; i++) {
                var d = dots[i];
                var target = L.latLng(d.latitude, d.longitude);
                var icon = L.icon({
                    iconUrl: d.thumbFile,
                    iconSize: [40, 40]
                });
                var marker = L.marker(target, {
                    id: d.thumbFile,
                    icon: icon
                });
                marker.on("click", function (e) {
                    console.log(e.sourceTarget.options.id);
                });
                marker.addTo(map);
                var elem = document.createElement("button");
                elem.textContent = d.title;
                elem.classList.add('row', 'btn', 'btn-primary');
                container.appendChild(elem);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('Error - ' + errorThrown);
        }
    });
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