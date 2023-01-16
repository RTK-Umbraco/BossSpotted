function blinkScreen() {
    console.log("here3");
    var body = document.getElementById("body");
    var colors = ['red', 'white'];
    var currentIndex = 0;
    setInterval(function () {
        console.log("here4");

        body.style.backgroundColor = colors[currentIndex]
       
        if (!colors[currentIndex]) {
            currentIndex = 0;
        } else {
            currentIndex++;
        }
    }, 50);

}