using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{

    // A game grid, we need to track state of game grid so we can read/write stuff onto it.
    public class GameBoardManager
    {
        public TileStates[,] GameBoard;

        public GameBoardManager(int boardWidth, int boardHeight)
        {
            GameBoard = new TileStates[boardWidth, boardHeight];

            //Initialise gameBoard
            for(int x = 0; x < boardWidth; x++) {
                for (int y = 0; y < boardHeight; y++) {
                    GameBoard[x, y] = TileStates._;
                }
            }
        }

        public GameBoardManager(TileStates[,] board)
        {
            GameBoard = board;
        }

        public void DisplayCurrentBoard()
        {
            Output.Display("  " + "A" + " " + "B" + " " + "C");
            for(int j = 0; j < 3; j++) {
                Output.Display((j + 1).ToString() + " " + GameBoard[0, j] + " " + GameBoard[1, j] + " " + GameBoard[2, j]);
            }
        }

        public List<TileStates> ReturnBoardAsList()
        {
            List<TileStates> tileList = new List<TileStates>();

            int width = GameBoard.GetLength(0);
            int height = GameBoard.GetLength(1);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    tileList.Add(GameBoard[x, y]);
                }
            }

            return tileList;
        }
    }

    // Stores the possible values for a tile. _ is empty
    public enum TileStates
    {
        _,
        O,
        X,
    }
}
