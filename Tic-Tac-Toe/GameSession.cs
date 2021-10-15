using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /*
     * Handles game sessions and turn state.
     */
    public class GameSession
    {
        int currentPlayer = 1; // Keeps track of which players turn it is
        public bool active = true;
        GameBoardManager boardManager;

        public GameSession(int gridSize)
        {
            boardManager = new GameBoardManager(gridSize, gridSize);
        }

        public GameSession(TileStates[,] board)
        {
            boardManager = new GameBoardManager(board);
        }

        public void ProcessTurn()
        {
            while (active) {
                boardManager.DisplayCurrentBoard();

                String playerInput = Console.ReadLine().ToLower();

                TakeTurn(playerInput);
            }
        }

        public bool UpdateBoard(int posX, int posY, int player)
        {
            int x = posX - 1;
            int y = posY - 1;

            // Set the corresponding tile for the current active player number.
            TileStates tile = player == 1 ? TileStates.O : TileStates.X;

            //First check tile is empty
            if (boardManager.GameBoard[x, y] == TileStates._) {
                //Set intended tile to either O or X.
                boardManager.GameBoard[x, y] = tile;
                return true;
            } else {
                return false;
            }
        }

        public void TakeTurn(String _playerInput)
        {
            String playerInput = _playerInput.ToLower();

            // Stores refs to potential tile positions we need to change
            int turnX = 0;
            int turnY = 0;

            //String playerInput = Console.ReadLine().ToLower();
            
            // Handle quit command
            if(playerInput.ToLower() == "quit") {
                active = false;
                return;
            }
            
            // Validate input and take the turn.
            if(ValidateInput(playerInput, ref turnX, ref turnY)) {
                if (UpdateBoard(turnX, turnY, currentPlayer) == true) {
                    //Check for a win condition
                    if (HasPlayerWon((TileStates)currentPlayer)) {
                        Output.Display(String.Format(Resource1.Win_message, currentPlayer));
                        active = false;
                    } else {                    
                        //No win? Cycle to next player
                        currentPlayer = currentPlayer == 1 ? 2 : 1;
                    }
                } else { // The attempted turn was invalid, try again.
                    Output.Display(Resource1.InvalidLocation);
                }
            } else
                Output.Display(Resource1.FailedValidation);
        }


        public bool HasPlayerWon(TileStates tile)
        {
            if (LineDiagonal(tile) || LineVertical(tile) || LineHorizontal(tile)) {
                return true;
            } else return false;
        }

        bool LineDiagonal(TileStates tile)
        {
            var board = boardManager.GameBoard;
            if((board[0,0] == tile && board[1,1] == tile && board[2,2] == tile) 
            || (board[0,2] == tile && board[1,1] == tile && board[2,0] == tile)) {
                return true;
            } else return false;
        }

        bool LineVertical(TileStates tile)
        {
            var board = boardManager.GameBoard;
            if((board[0,0] == tile && board[0,1] == tile && board[0,2] == tile)
                || (board[1, 0] == tile && board[1, 1] == tile && board[1, 2] == tile)
                || (board[2, 0] == tile && board[2, 1] == tile && board[2, 2] == tile)) {
                return true;
            } return false;
        }

        bool LineHorizontal(TileStates tile)
        {
            var board = boardManager.GameBoard;
            if ((board[0, 0] == tile && board[1, 0] == tile && board[2, 0] == tile)
                || (board[0, 1] == tile && board[1, 1] == tile && board[2, 1] == tile)
                || (board[0, 2] == tile && board[1, 2] == tile && board[2, 2] == tile)) {
                return true;
            }
            return false;
        }

        public bool ValidateInput(String inputToValidate, ref int posX, ref int PosY)
        {
            // Turn commands should be in the form of LETTER -> NUMBER e.g. B2 for the middle spot
            String x = inputToValidate.Substring(0, 1);
            String y = inputToValidate.Substring(1, 1);

            if (Char.IsLetterOrDigit(x, 0) && Char.IsLetterOrDigit(y, 0)) {
                //Correctly formatted turn
                switch (x) {
                    case "a":
                        posX = 1;
                        break;
                    case "b":
                        posX = 2;
                        break;
                    case "c":
                        posX = 3;
                        break;
                    default:
                        return false;
                }
                switch (y) {
                    case "1":
                        PosY = 1;
                        break;
                    case "2":
                        PosY = 2;
                        break;
                    case "3":
                        PosY = 3;
                        break;
                    default:
                        return false;
                }
                // Success! The turn is valid.
                return true;
            } else return false;
        }
    }
}
