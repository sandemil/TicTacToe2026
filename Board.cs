using System.Collections;

namespace TicTacToe
{
    //          FALL #1:
    // VAD:     Iterator pattern (IEnumerable och IEnumerator)
    // HUR:     Board implementerar IEnumerable<char> genom att anropa
    //          GetEnumerator() på den privata arrayen cells.
    //          NumberedBoard och MinimalBoard går igenom brädet med
    //          foreach (char mark in board).
    // VARFÖR:  Brädstilarna kan läsa rutorna i ordning utan att arrayen
    //          görs public, så de kan inte skriva direkt i den. Board
    //          kan byta intern lagring (t.ex. till char[3,3]) utan att
    //          brädstilarna behöver ändras.
    public class Board : IEnumerable<char>
    {
        private readonly char[] cells;
        private readonly GameHistory<MoveRecord> moves =
            new GameHistory<MoveRecord>();

        public Board()
        {
            cells = new char[9];
            Array.Fill(cells, ' ');
        }

        // Dragen som spelats på brädet, i ordning. 
        // Används för att spara ställningen och för att bygga upp den igen
        public GameHistory<MoveRecord> Moves
        {
            get { return moves; }
        }

        public bool IsEmpty(int position)
        {
            return cells[position - 1] == ' ';
        }

        public void Place(int position, char symbol)
        {
            cells[position - 1] = symbol;
        }

        // Ett riktigt drag, som sparas i historiken. 
        // AI:n använder Place och Clear direkt när den bara testar ett drag
        public void Play(int position, char symbol)
        {
            Place(position, symbol);
            moves.Add(new MoveRecord(symbol, position));
        }

        // Tömmer brädet och spelar upp de sparade dragen igen
        public void Restore(GameHistory<MoveRecord> saved)
        {
            Array.Fill(cells, ' ');
            moves.Clear();

            for (int i = 0; i < saved.Count; i++)
            {
                MoveRecord move = saved.Get(i);
                Play(move.Position, move.Symbol);
            }
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