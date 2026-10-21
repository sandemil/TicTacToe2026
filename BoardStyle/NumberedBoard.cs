using System;

namespace TicTacToe
{
    public class NumberedBoard : IBoardStyle
    {
        public void Render(Board board)
        {
            Console.WriteLine();
            int position = 1;
            foreach (char mark in board)
            {
                string cell = mark == ' '
                    ? position.ToString()
                    : mark.ToString();
                Console.Write(" " + cell + " ");

                if (position % 3 != 0)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.WriteLine();
                    if (position < 9)
                    {
                        Console.WriteLine("---+---+---");
                    }
                }
                position++;
            }
            Console.WriteLine();
        }
    }
}