namespace TicTacToe
{
    public class ReverseGameMode : IGameMode
    {
        public string Name
        {
            get { return "Reverse"; }
        }

        // Kollar hela tiden om någon har fått tre i rad. Om ja, returnera den andra spelarens char
        public char GetWinningSymbol(Board board)
        {
            char lined = board.GetWinner();
            if (lined == ' ')
            {
                return ' ';
            }

            if (lined == 'X')
            {
                return 'O';
            }

            return 'X';
        }
    }
}