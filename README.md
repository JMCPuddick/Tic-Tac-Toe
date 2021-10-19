## TIC-TAC-TOE ##
Made by Jonathan Puddick in approximately 2 hours but probably closer to 3.
==============================================================================================

Instructions:
Players take turns inputting commands in the console (e.g. "b2") and they will see their output updated after a successful move.
Once a line of three has been made by a player, the game ends and that player is victorious.

The idea was to get the basic end-to-end experience developed and working in the alotted time. I aimed for simplicity, and leveraged an easy understanding of 2d arrays and nested for loops.
While this may not be the most performant, it was the easiest to work with and I felt that it maintains a good level of readability.

FLOW
The core flow of the code works as follows.

Game starts: 
1. We initialise a 2D array of TileType enums which contain the three states of our tiles (either blank tile, a O or a X). Initially, the array is a 3x3 grid of the "_" character like so:
______________________________
  public enum TileStates
    {
        _,
        O,
        X,
    }
______________________________

2. We then begin with player 1, who has to input a command that describes their move. The code reads the line, and performs validation on the command as follows:
	- Split the string so we get the first char and second char as separate variables using string.Substring().
	- 2 switch statements process each intended coordinate of the input to determine it's intended location on the grid.
	- The function updates 2 ref parameters to these x and y co-ordinates, and the calling code then has updated posX and posY values for a valid move 	to process.

3. A valid move has been found, and we have the co-ordinates, so we update the grid with the intended TileType by referring the players number (stored in the player object) as an int identifier to pull the correct player tile. e.g. (TileStates)player.number if player number is 2 will return (enum)2 which in this case, is the X tile.

4. Following each move, we check for a win condition to see if that move has created a line of three. Here, the code could probably be more elegant, as we are currently checking for true on three blocks of if statements and iterating over tiles multiple times to ascertain a horizontal, vertical, or diagonal win condition. This could definitely be improved, perhaps by using tilemaps to compare to, or by querying each valid middle tile and it's neighbours to ascertain any lines of three. But for now, big blocks of (if && if) || (if && if) seem to work fine.

5. If no win conditions are met, we cycle to the next player and repeat the process from step 2.


*It should be noted that the required character is "-" for an empty tile, but it is protected, so I decided to continue working on functionality rather than fix this. But it can be addressed in later stages.

===========================================================
THOUGHTS

I wanted initially to get the main functionality working. There are definitely improvements that can be made, and the unit testing, while covering basic functionality, would be my next area of focus. However I did make sure to cover validation and win conditions with tests, as these are the core gameplay elements that pin it together.

I would like to introduce the Moq framework to mock some different game boards and be more explicit in unit tests to test more specific elements of the game's flow. There may be value in being able to mock function output to support individually testing parts of the turn flow. While it could probably all work without Moq, it would likely help unit testing be more concise.

Furthermore, I feel that further levels of abstraction can be achieved, and some of the validation and win-conditions checking should be abstracted out.

MOVING FORWARD
===========================================================
To extend the project, I would like to have more customisable player involvement. Being able to let them input a name and have some win tables persisted. So players can keep a running tally of their wins, losses and draws.

The above would mean that a game session could consist of multiple games, and the code would also need to be extended to check for the presence of a draw. (Done simply, if no more tiles are TileTypes._ and no win conditions are met, we can safely assume we have a draw, so reset the board and start again.)

A neat thing might be to have customisable board sizes. I initially built in support for that in the board initialisation stage, but turn validation and win-conditions checking would need to be extended to read the board-size and work accordingly.

If the project was to increase in size and scope, some refactoring would be useful to maintain a separation of concerns. While not the neatest at the moment, the game works well enough to fit the brief.


