var filled;
var content;
var winningCombinations;
var turn = 0;
var blockFilled = 0;
var block;
var index;
var context;

window.onload = function () {
    filled = new Array();
    content = new Array();
    winningCombinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 4, 8], [2, 4, 6], [0, 3, 6], [1, 4, 7], [2, 5, 8]];
    for (var blocks = 0; blocks <= 8; blocks++) {
        filled[blocks] = false;
        content[blocks] = '';
    }
}
function takeActionOnClick(canvasId) {
    block = "canvas" + canvasId;
    index = document.getElementById(block);
    context = index.getContext("2d");
    if (filled[canvasId - 1] == false) {
        if (turn % 2 == 0) {
            context.beginPath();
            context.moveTo(10, 10);
            context.lineTo(40, 40);
            context.moveTo(40, 10);
            context.lineTo(10, 40);
            context.stroke();
            context.closePath();
            content[canvasId - 1] = 'X';
        }
        else {
            context.beginPath();
            context.arc(25, 25, 20, 0, Math.PI * 2, true);
            context.stroke();
            context.closePath();
            content[canvasId - 1] = 'O';
        }
        turn++;
        filled[canvasId - 1] = true;
        blockFilled++;
        checkWinner(content[canvasId - 1]);
        if (blockFilled == 9) {
            alert("Game Completed!! Draw Game !!");
            location.reload(true);
        }
    }
    else{
        alert("Block is already filled");
    }
}
function checkWinner(player) {
    for (var win = 0; win < winningCombinations.length; win++) {
        if (content[winningCombinations[win][0]] == player && content[winningCombinations[win][1]] == player && content[winningCombinations[win][2]] == player) {
            alert(player + " WON!");
        }
    }
}
function reset() {
    location.reload(true);
}