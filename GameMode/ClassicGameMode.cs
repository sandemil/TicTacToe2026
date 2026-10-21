namespace TicTacToe
{
    public class ClassicGameMode : IGameMode
    {
        public string Name
        {
            get { return "Classic"; }
        }

        public char GetWinningSymbol(Board board)
        {
            return board.GetWinner();
        }
    }
}