var audio = document.getElementById('alertBoss');

function playAlert() {
    audio.play();
}

function stopAlert() {
    audio.pause();
    audio.currentTime = 0;
}