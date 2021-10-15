using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class BoardManagerTests
    {
        GameBoardManager testManager;
        
        [Fact]
        public void ManagerCanCreateEmptyBoard()
        {
            // Arrange
            int boardSize = 3;

            // Act
            testManager = new GameBoardManager(boardSize, boardSize);
            // Convert the tiles to list for esier assertion
            var tilesList = testManager.ReturnBoardAsList();

            // Assert
            Assert.All(tilesList, t => Assert.Equal(TileStates._, t));
        }
    }
}
