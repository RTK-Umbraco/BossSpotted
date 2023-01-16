function blinkScreen() {
    var body = document.getElementById("body");
    var colors = ['red', 'white'];
    var currentIndex = 0;
    var timesRun = 0; 
    var blinkInterval = setInterval(function () {

        body.style.backgroundColor = colors[currentIndex]
       
        if (!colors[currentIndex]) {
            currentIndex = 0;
        } else {
            currentIndex++;
        }
        timesRun++;
        if (timesRun > 50) {
            clearInterval(blinkInterval);
        }

    }, 50);

}