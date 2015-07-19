var step = 5;
var timeout = 10;
var height = 0;
var width = 0;
var yFlag = false;
var xFlag = false;
var interval;
var xPosition = 20;
var yPosition = 20;

function moveBall() {
    height = window.innerHeight - 100;
    width = window.innerWidth - 100;
    document.getElementById('ball').style.top = yPosition;
    document.getElementById('ball').style.left = xPosition;
    if (yFlag) {
        yPosition = yPosition + step;
    }
    else {
        yPosition = yPosition - step;
    }
    if (yPosition < 0) {
        yFlag = true;
        yPosition = 0;
    }
    if (yPosition >= (height)) {
        yFlag = false;
        yPosition = (height);
    }
    if (xFlag) {
        xPosition = xPosition + step;
    }
    else {
        xPosition = xPosition - step;
    }
    if (xPosition < 0) {
        xFlag = true;
        xPos = 0;
    }
    if (xPosition >= (width)) {
        xFlag = false;
        xPosition = (width);
    }
}
function start() {
    interval = setInterval(moveBall, timeout);
}
start();