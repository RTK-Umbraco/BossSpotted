"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bossSpottedHub").build();
isSignalConnected(false);
connection.on("BossHasBeenSpotted", function (seriousness) {
    if(seriousness == 1 || seriousness == 2)
        playAlert();
    blinkScreen(seriousness);
    setTimeout(stopAlert, 7000)
});


connection.start().then(function () {
    isSignalConnected(true);
    }).catch(function (err) {
        return console.error(err.toString());
});
