using System;

namespace TICTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            var ticTacToeGame = new TicTacToeGame();
            ticTacToeGame.InitializeBoard();
            
            char player = ticTacToeGame.ChooseOption();
            char computer = player == 'X' ? 'O' : 'X'; 
        }
    }
}
