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
        public enum Player { User, Computer};
        public enum GameStatus { Won, FullBoard, Continue };

        public TicTacToeGame()
        {       
        }
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
            for(int i = 1; i<10 ; i++)
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

        public void MakeMove(char ch)
        {
            if (ch == player)
            {
                Console.Write("Choose an Index to mark : ");
                var index = Convert.ToInt32(Console.ReadLine());
                MoveIfFree(index,ch);
            }
            else
            {
                var computerMove = GetComputerMove();
                if (computerMove != 0)
                    MoveIfFree(computerMove, ch);
            }
                      
        }
        public void MoveIfFree(int index, char ch)
        {
            if (index <= 0 || index > 9)
            {
                Console.WriteLine("Invalid Input!\nTry Again");
                MakeMove(ch);
            }
            else if (!isFree(index))
            {
                Console.WriteLine("The Location is not empty please select a different location..,.");
                MakeMove(ch);   
            }
            else
            {
                board[index] = ch;
            }
        }

        public bool isFree(int index)
        {
            return board[index] == ' ';
        }

        public Player Toss()
        {
            return new Random().Next(0, 2) == 1 ? Player.User : Player.Computer;
        }

        public bool IsWinner(char[] board,char ch)
        {
            return ((board[1] == ch && board[2] == ch && board[3] == ch) ||
                    (board[4] == ch && board[5] == ch && board[6] == ch) ||
                    (board[7] == ch && board[8] == ch && board[9] == ch) ||
                    (board[1] == ch && board[4] == ch && board[7] == ch) ||
                    (board[2] == ch && board[5] == ch && board[8] == ch) ||
                    (board[3] == ch && board[6] == ch && board[9] == ch) ||
                    (board[1] == ch && board[5] == ch && board[9] == ch) ||
                    (board[3] == ch && board[5] == ch && board[7] == ch));
        }

        public int GetComputerMove()
        {
            var currentMove = GetWinningMove(computer);
            if (currentMove != 0)
                return currentMove;
            currentMove = GetWinningMove(player);
            if (currentMove != 0)
                return currentMove;
            int[] corners = { 1, 3, 7, 9 };
            currentMove = GetRandomMove(corners);
            if (currentMove != 0)
                return currentMove;
            currentMove = 5;
            if (isFree(currentMove))
                return currentMove;
            int[] sides = { 2, 4, 6, 8 };
            currentMove = GetRandomMove(sides);
            if (currentMove != 0)
                return currentMove;
            return 0;
        }
        public int GetWinningMove(char ch)
        {
            for(int index = 1; index < 10; index++)
            {
                var boardCopy = board;
                if (boardCopy[index] == ' ')
                {
                    boardCopy[index] = ch;
                    if (IsWinner(boardCopy,ch))
                        return index;
                }
            }
            return 0;
        }

        public int GetRandomMove(int[] moves)
        {
            var possibleMoves = new List<int>();
            foreach (var item in moves)
                if (isFree(item))
                    possibleMoves.Add(item);
            if (possibleMoves.Count == 0)
                return 0;
            var random = new Random();
            while (true)
            {
                int index = random.Next(0, possibleMoves.Count);
                if (isFree(possibleMoves[index]))
                    return possibleMoves[index];
            }
        }

        public GameStatus CurrentStatus()
        {
            var isFull = true;
            foreach (var item in board)
                if (item == ' ' )
                    isFull = false;
            if (isFull)
                return GameStatus.FullBoard;
            else if (IsWinner(board,player) || IsWinner(board,computer))
                return GameStatus.Won;
            else
                return GameStatus.Continue;
        }
  
    }
}
