using System;
using System.Reflection.PortableExecutable;

namespace TICTacToeGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            var consolMessage = "1.Start a New Tic Tac Toe Game\n2.Exit\nPlease select an Option : ";
            var quit = false;
            while (!quit)
            {
                Console.Write(consolMessage);
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }

            }

        }

        public static void StartGame()
        {
            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.InitializeBoard();
            ticTacToeGame.player = ticTacToeGame.ChooseOption();
            ticTacToeGame.computer = ticTacToeGame.player == 'X' ? 'O' : 'X';
            ticTacToeGame.ShowBoard();
            Console.WriteLine("Doing Toss.....");
            var player = ticTacToeGame.Toss();
            var tossMessage = player == TicTacToeGame.Player.User ? "You have the first turn" : "Computer has the first turn";
            Console.WriteLine(tossMessage);
            var gameOver = false;
            var gameStatus = ticTacToeGame.CurrentStatus();
            var winMessage = "";
            while (!gameOver)
            {

                if (player == TicTacToeGame.Player.User)
                {
                    ticTacToeGame.MakeMove(ticTacToeGame.player);
                    winMessage = "Congrats! Jeet gaye aap.";
                    gameStatus = ticTacToeGame.CurrentStatus();
                    player = TicTacToeGame.Player.Computer;
                }
                else
                {
                    Console.WriteLine("Computer's Turn...");
                    ticTacToeGame.MakeMove(ticTacToeGame.computer);
                    winMessage = "You Lost. Computers are smart bro.";
                    gameStatus = ticTacToeGame.CurrentStatus();
                    player = TicTacToeGame.Player.User;
                }
                if (gameStatus != TicTacToeGame.GameStatus.Continue)
                    gameOver = true;
                ticTacToeGame.ShowBoard();
            }
            var message = gameStatus == TicTacToeGame.GameStatus.FullBoard ? "Board is Full. It's a Tie!" : winMessage;
            Console.WriteLine(message);
        }

    }
}
