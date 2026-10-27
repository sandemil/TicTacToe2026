namespace TicTacToe
{
    // Håller reda på ställningen i en turnering och skriver ut den
    public class Scoreboard
    {
        private readonly MatchSettings settings;
        private int humanWins;
        private int computerWins;
        private int roundsPlayed;

        public Scoreboard(MatchSettings settings)
        {
            this.settings = settings;
        }

        public int StartRound()
        {
            roundsPlayed++;
            Console.WriteLine();
            Console.WriteLine("Round " + roundsPlayed);
            PrintScore("Score");
            return roundsPlayed;
        }

        public void Record(string winner)
        {
            if (winner == settings.Human.Name)
            {
                humanWins++;
            }
            else if (winner == settings.Computer.Name)
            {
                computerWins++;
            }
        }

        public bool IsFinished(ITournamentEndCondition endCondition)
        {
            //          FALL #6:
            // VAD:     Strategy pattern
            // HUR:     BestOfX, FirstToX och UntilPlayerQuits
            //          injiceras som ITournamentEndCondition i
            //          Tournament, som skickar den hit. Efter varje
            //          runda anropas IsFinished().
            // VARFÖR:  Tournament och Scoreboard innehåller inte
            //          reglerna för när turneringen ska sluta. En ny
            //          turneringstyp kan läggas till utan att någon
            //          av dem ändras.
            return endCondition.IsFinished(
                humanWins, computerWins, roundsPlayed);
        }

        public string GetWinner()
        {
            if (humanWins > computerWins)
            {
                return settings.Human.Name;
            }
            if (computerWins > humanWins)
            {
                return settings.Computer.Name;
            }
            return "Draw";
        }

        public void PrintResult()
        {
            Console.WriteLine();
            PrintScore("Final score");
            string winner = GetWinner();
            if (winner == "Draw")
            {
                Console.WriteLine("The tournament ended in a draw.");
            }
            else
            {
                Console.WriteLine(winner + " wins the tournament!");
            }
        }

        public void PrintScore(string label)
        {
            Console.WriteLine(label
                + ": Player " + humanWins
                + " - Computer " + computerWins);
        }
    }
}