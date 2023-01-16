"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bossSpottedHub").build();

connection.on("BossHasBeenSpotted", function () {
    blinkScreen();
});

connection.start();