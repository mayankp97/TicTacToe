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
            
            ticTacToeGame.player = ticTacToeGame.ChooseOption();
            ticTacToeGame.computer = ticTacToeGame.player == 'X' ? 'O' : 'X';
            ticTacToeGame.ShowBoard();
        }
    }
}
