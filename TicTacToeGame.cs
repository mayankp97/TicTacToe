using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TICTacToeGame
{
    class TicTacToeGame
    {
        public char[] board { get; set; }
        public char player { get; set; }
        public char computer { get; set; }

        public void InitializeBoard()
        {
            board = new char[10];
            for (int i = 1; i < 10; i++)
                board[i] = ' ';
        }

        public char ChooseOption()
        {
            Console.Write("Choose X or O : ");
            var input = Convert.ToChar(Console.ReadLine());
            return (input == 'X' || input == 'O') ? input : ChooseOption();
        }

  
    }
}
