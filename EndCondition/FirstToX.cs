namespace TicTacToe
{
    public class FirstToX : ITournamentEndCondition
    {
        private readonly int wins;

        public FirstToX(int wins)
        {
            this.wins = wins;
        }

        public string Name
        {
            get { return "First to " + wins; }
        }

        // returnerar true när någon nått x i "first to x"
        public bool IsFinished(
            int humanWins, int computerWins, int roundsPlayed)
        {
            return humanWins >= wins || computerWins >= wins;
        }
    }
}