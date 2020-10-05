using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TICTacToeGame
{
    class TicTacToeGame
    {
        public char[] board = new char[10];


        public TicTacToeGame()
        {
            for (int i = 0; i < 10; i++)
                board[i] = ' ';
        }
    }
}
