function isSignalConnected(isConnected) {
    if (isConnected == true) {
        document.getElementById("sendButton").style.backgroundColor = "green";
    }
    else if (isConnected == false) {
        document.getElementById("sendButton").style.backgroundColor = "red";
    }
}