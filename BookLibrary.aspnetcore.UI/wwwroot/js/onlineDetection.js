
window.addEventListener('load', function (e) {
    updateOnlineStatus(navigator.onLine);
}, false);

window.addEventListener('online', function (e) {
    updateOnlineStatus(true);
}, false);

window.addEventListener('offline', function (e) {
    updateOnlineStatus(false);
}, false);

function updateOnlineStatus(online) {
    var osm = document.getElementById('onlineStatusMessage');
    if (online) {
        osm.innerHTML = '<span class="label label-success">Online</span>';
    } else {
        osm.innerHTML = '<span class="label label-danger">Offline</span>';
    }
}