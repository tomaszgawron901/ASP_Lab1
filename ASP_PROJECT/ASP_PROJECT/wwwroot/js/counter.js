"use strict";

var counterConnection = new signalR.HubConnectionBuilder().withUrl("/counterHub").build();


counterConnection.on("ConnectionsChange", function (connections) {
    document.getElementById("connections").innerText = connections;
});

counterConnection.start();