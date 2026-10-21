namespace TicTacToe
{
    public class MoveRecord : IGameRecord
    {
        public char Symbol { get; }
        public int Position { get; }

        public MoveRecord(char symbol, int position)
        {
            Symbol = symbol;
            Position = position;
        }

        public string Describe()
        {
            return Symbol + " -> " + Position;
        }
    }
}
