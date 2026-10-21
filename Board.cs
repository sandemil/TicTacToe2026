using System.Collections;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board : IEnumerable<char>
    {
        private readonly char[] cells;

        public Board()
        {
            cells = new char[9];
            for (int i = 0; i < 9; i++)
            {
                cells[i] = ' ';
            }
        }

        public bool IsEmpty(int position)
        {
            return cells[position - 1] == ' ';
        }

        public void Place(int position, char symbol)
        {
            cells[position - 1] = symbol;
        }

        public void Clear(int position)
        {
            cells[position - 1] = ' ';
        }

        public List<int> GetEmptyPositions()
        {
            List<int> empty = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (cells[i] == ' ')
                {
                    empty.Add(i + 1);
                }
            }
            return empty;
        }

        public bool IsFull()
        {
            for (int i = 0; i < 9; i++)
            {
                if (cells[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public char GetWinner()
        {
            int[,] lines =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 },
                { 1, 5, 9 },
                { 3, 5, 7 }
            };

            for (int i = 0; i < 8; i++)
            {
                char a = cells[lines[i, 0] - 1];
                char b = cells[lines[i, 1] - 1];
                char c = cells[lines[i, 2] - 1];
                if (a != ' ' && a == b && b == c)
                {
                    return a;
                }
            }

            return ' ';
        }

        //          FALL #8:
        // VAD:     Iterator, Board implementerar IEnumerable<char>.
        // HUR:     GetEnumerator() lämnar vidare cells egen enumerator,
        //          och renderarna går igenom brädet med foreach.
        // VARFÖR:  Renderarna behöver inte veta hur brädet lagras
        //          eller räkna ut positioner, och de kan bara läsa
        //          rutorna, inte ändra dem.
        public IEnumerator<char> GetEnumerator()
        {
            return ((IEnumerable<char>)cells).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}