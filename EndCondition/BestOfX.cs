namespace TicTacToe
{
    public class BestOfX : ITournamentEndCondition
    {
        private readonly int rounds;

        public BestOfX(int rounds)
        {
            this.rounds = rounds;
        }

        public string Name
        {
            get { return "Best of " + rounds; }
        }

        // när alla x rundor är spelade, eller när ledningen är för stor
        public bool IsFinished(
            int humanWins, int computerWins, int roundsPlayed)
        {
            int roundsLeft = rounds - roundsPlayed;
            int lead = Math.Abs(humanWins - computerWins);
            return roundsLeft == 0 || lead > roundsLeft;
        }
    }
}