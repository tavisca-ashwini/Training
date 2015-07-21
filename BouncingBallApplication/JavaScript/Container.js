window.BouncingBall = window.BouncingBall || {}

window.BouncingBall.boundryCondition = function () {

    var height = window.innerHeight - 100;
    var width = window.innerWidth - 100;

    if (window.BouncingBall.yPosition < 0) {
        window.BouncingBall.yFlag = true;
        window.BouncingBall.yPosition = 0;
    }
    if (window.BouncingBall.yPosition >= (height)) {
        window.BouncingBall.yFlag = false;
        window.BouncingBall.yPosition = (height);
    }

    if (window.BouncingBall.xPosition < 0) {
        window.BouncingBall.xFlag = true;
        window.BouncingBall.xPosition = 0;
    }
    if (window.BouncingBall.xPosition >= (width)) {
        window.BouncingBall.xFlag = false;
        window.BouncingBall.xPosition = (width);
    }
}