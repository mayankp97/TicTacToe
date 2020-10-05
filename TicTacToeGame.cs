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
            var input = char.ToUpper(Convert.ToChar(Console.ReadLine()));
            return (input == 'X' || input == 'O') ? input : ChooseOption();
        }

        public void ShowBoard()
        {
            for(int i = 1; i<10; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write("{0}\n",board[i]);
                    if(i!=9)
                        Console.WriteLine("------------");
                }
                else
                    Console.Write(" {0} |",board[i]);
            }
        }

        public void MakeMove()
        {
            Console.Write("Choose an Index to mark : ");
            var index = Convert.ToInt32(Console.ReadLine());
            if (board[index] != ' ')
            {
                Console.WriteLine("The Location is not empty please select a different location");
                MakeMove();
            }
            else
            {
                board[index] = player;
                ShowBoard();
            }
                      
        }
  
    }
}
