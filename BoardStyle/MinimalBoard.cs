using System;

namespace TicTacToe
{
    public class MinimalBoard : IBoardStyle
    {
        public void Render(Board board)
        {
            Console.WriteLine();
            int column = 0;
            foreach (char mark in board)
            {
                char symbol = mark == ' ' ? '.' : mark;
                Console.Write(" " + symbol);

                column++;
                if (column == 3)
                {
                    Console.WriteLine();
                    column = 0;
                }
            }
            Console.WriteLine();
        }
    }
}