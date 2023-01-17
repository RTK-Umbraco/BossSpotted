"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bossSpottedHub").build();
isSignalConnected(false);
connection.on("BossHasBeenSpotted", function () {
    blinkScreen();
});

connection.start().then(function () {
    isSignalConnected(true);
    }).catch(function (err) {
        return console.error(err.toString());
});
