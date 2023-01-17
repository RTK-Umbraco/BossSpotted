function blinkScreen(seriousness) {
    var body = document.getElementById("body");
    var colors = ['white'];
    if (seriousness == 0)
        colors.push('green');
    else if (seriousness == 1)
        colors.push('yellow');
    else if (seriousness == 2)
        colors.push('red');
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
        if (timesRun > 51) {
            clearInterval(blinkInterval);
        }

    }, 50);

}