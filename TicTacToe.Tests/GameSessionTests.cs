using Xunit;

namespace TicTacToe.Tests
{
    public class GameSessionTests
    {
        // Arrange
        public int testGridSize = 3;
        GameSession testSession;
        
        [Fact]
        public void PlayerTriesInvalidCommand_Unable()
        {
            // Arrange
            testSession = new GameSession(testGridSize);
            GameBoardManager testGameBoard = new GameBoardManager(3, 3);
            var userCommand = "x5";
            int posX = 0;
            int posY = 0;

            // Act
            testSession.TakeTurn(userCommand);

            // Assert
            Assert.False(testSession.ValidateInput(userCommand, ref posX, ref posY));
            //An invalid command should leave posX and posY unchanged;
            Assert.Equal(0, posX);
            Assert.Equal(0, posY);
        }

        [Fact]
        public void PlayerTriesValidCommand_Able()
        {
            // Arrange
            testSession = new GameSession(testGridSize);
            GameBoardManager testGameBoard = new GameBoardManager(3, 3);
            var userCommand = "a1";
            int posX = 0;
            int posY = 0;

            // Act
            testSession.TakeTurn(userCommand);

            // Assert
            Assert.True(testSession.ValidateInput(userCommand, ref posX, ref posY));
            //A valid command should update posX and posY;
            Assert.Equal(1, posX);
            Assert.Equal(1, posY);
            Assert.True(testSession.active);
        }

        [Fact]
        public void PlayerMakesWinningMoveHorizontal_GameEnds()
        {
            // Arrange (initialisation like this rotates the grid, as nested for loops used elsewhere iterate differently)
            TileStates[,] boardInProgress = new TileStates[3, 3] { 
                     /*     1             2             3       */
         /*A*/       { TileStates.O, TileStates.O, TileStates._ },
         /*B*/       { TileStates._, TileStates._, TileStates._ },
         /*C*/       { TileStates._, TileStates._, TileStates._ }};
            GameSession testSession = new GameSession(boardInProgress);

            var userCommand = "a3";
            int posX = 0;
            int posY = 0;

            // Act
            testSession.TakeTurn(userCommand);

            // Assert
            Assert.True(testSession.ValidateInput(userCommand, ref posX, ref posY));
            Assert.True(testSession.HasPlayerWon(TileStates.O));
            //A valid command should update posX and posY;
            Assert.Equal(1, posX);
            Assert.Equal(3, posY);
            Assert.False(testSession.active);
        }
        [Fact]
        public void PlayerMakesWinningMoveVertical_GameEnds()
        {
            TileStates[,] boardInProgress = new TileStates[3, 3] { 
                     /*     1             2             3       */
         /*A*/       { TileStates._, TileStates._, TileStates.O },
         /*B*/       { TileStates._, TileStates._, TileStates._ },
         /*C*/       { TileStates._, TileStates._, TileStates.O }};
            GameSession testSession = new GameSession(boardInProgress);

            var userCommand = "b3";
            int posX = 0;
            int posY = 0;

            // Act
            testSession.TakeTurn(userCommand);

            // Assert
            Assert.True(testSession.ValidateInput(userCommand, ref posX, ref posY));
            Assert.True(testSession.HasPlayerWon(TileStates.O));
            //A valid command should update posX and posY;
            Assert.Equal(2, posX);
            Assert.Equal(3, posY);
            Assert.False(testSession.active);
        }

        [Fact]
        public void PlayerMakesWinningMoveDiagonal_GameEnds()
        {
            TileStates[,] boardInProgress = new TileStates[3, 3] { 
                     /*     1             2             3       */
         /*A*/       { TileStates.O, TileStates._, TileStates._ },
         /*B*/       { TileStates._, TileStates._, TileStates._ },
         /*C*/       { TileStates._, TileStates._, TileStates.O }};
            GameSession testSession = new GameSession(boardInProgress);

            var userCommand = "b2";
            int posX = 0;
            int posY = 0;

            // Act
            testSession.TakeTurn(userCommand);

            // Assert
            Assert.True(testSession.ValidateInput(userCommand, ref posX, ref posY));
            Assert.True(testSession.HasPlayerWon(TileStates.O));
            //A valid command should update posX and posY;
            Assert.Equal(2, posX);
            Assert.Equal(2, posY);
            Assert.False(testSession.active);
        }
    }
}
