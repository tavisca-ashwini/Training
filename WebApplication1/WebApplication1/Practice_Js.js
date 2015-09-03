var MyGame = function(user) {
    user = prompt("What would you like to play ?", "Enter Here").toUpperCase();
    //var player1, player2;
    switch(user)
    {
        case 'Tic-Tac-Toe' :
            document.write("Selected Tic-Tac-Toe");
            break;

        case 'Chess':
            document.write("Selected Chess");
            break;

        case 'CS':
            document.write("Selected CS");
            break;

        default:
            document.write("Game is not included");
    }
};