using System;

namespace TicTacToe
{
    class Program
    {
        public const int gridSize = 3;
        public static bool gameInProgress = true;

        static void Main(string[] args)
        {
            GameSession session = new GameSession(gridSize);

            Player player1 = new Player("player1", 1);
            Player player2 = new Player("player2", 2);

            Output.Display(Resource1.Welcome);
            Output.Display(Resource1.Instructions);
            Output.Display(Resource1.Instructions2);
            Output.Display("========================================");
            Output.Display(Resource1.NewTurnInstruct1);
            Output.Display(Resource1.NewTurnInstruct2);
            
            session.ProcessTurn();
        }
    }
}
