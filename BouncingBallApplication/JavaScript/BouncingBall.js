window.BouncingBall = window.BouncingBall || {
    yFlag: false,
    xFlag: false,
    xPosition: 20,
    yPosition: 20,
}
var step = 5;

window.BouncingBall.moveBall = function () {

    document.getElementById('ball').style.top = window.BouncingBall.yPosition;
    document.getElementById('ball').style.left = window.BouncingBall.xPosition;

    window.BouncingBall.boundryCondition();
    if (window.BouncingBall.yFlag) {
        window.BouncingBall.yPosition = window.BouncingBall.yPosition + step;
    }
    else {
        window.BouncingBall.yPosition = window.BouncingBall.yPosition - step;
    }
    if (window.BouncingBall.xFlag) {
        window.BouncingBall.xPosition = window.BouncingBall.xPosition + step;
    }
    else {
        window.BouncingBall.xPosition = window.BouncingBall.xPosition - step;
    }
}
window.BouncingBall.start = function () {
    setInterval(BouncingBall.moveBall, 20);
}