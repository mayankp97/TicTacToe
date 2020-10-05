using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TICTacToeGame
{
    class TicTacToeGame
    {
        public char[] board { get; set; }

        public void InitializeBoard()
        {
            board = new char[10];
            for (int i = 1; i < 10; i++)
                board[i] = ' ';
        }
    }
}
