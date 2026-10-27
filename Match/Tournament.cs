namespace TicTacToe
{
    // Spelar rundor tills end condition säger att turneringen är slut
    public class Tournament : IMatch
    {
        private readonly MatchSettings settings;
        private readonly ITournamentEndCondition endCondition;

        public Tournament(
            MatchSettings settings,
            ITournamentEndCondition endCondition)
        {
            this.settings = settings;
            this.endCondition = endCondition;
        }

        public void Play()
        {
            int humanWins = 0;
            int computerWins = 0;
            int roundsPlayed = 0;

            //          FALL #6:
            // VAD:     Strategy pattern
            // HUR:     BestOfX, FirstToX och UntilPlayerQuits injiceras som
            //          ITournamentEndCondition i Tournament. Efter varje runda
            //          anropas IsFinished() för att avgöra om tournamentet är slut.
            // VARFÖR:  Tournament innehåller bara loopen och poängräkningen,
            //          inte reglerna för när den ska sluta. En ny turneringstyp
            //          kan läggas till utan att Tournament ändras.
            do
            {
                roundsPlayed++;
                Console.WriteLine();
                Console.WriteLine("Round " + roundsPlayed);
                PrintScore("Score", humanWins, computerWins);

                Round round = new Round(settings, roundsPlayed);
                string winner = round.Play();
                if (winner == settings.Human.Name)
                {
                    humanWins++;
                }
                else if (winner == settings.Computer.Name)
                {
                    computerWins++;
                }
            }
            while (!endCondition.IsFinished(
                humanWins, computerWins, roundsPlayed));

            string matchWinner = "Draw";
            if (humanWins > computerWins)
            {
                matchWinner = settings.Human.Name;
            }
            else if (computerWins > humanWins)
            {
                matchWinner = settings.Computer.Name;
            }

            Console.WriteLine();
            PrintScore("Final score", humanWins, computerWins);
            if (matchWinner == "Draw")
            {
                Console.WriteLine("The tournament ended in a draw.");
            }
            else
            {
                Console.WriteLine(matchWinner + " wins the tournament!");
            }

            settings.Results.Add(new MatchResult(
                matchWinner,
                settings.Difficulty,
                settings.Mode.Name,
                endCondition.Name));
        }

        // Skriver ut ställningen
        private void PrintScore(string label, int humanWins, int computerWins)
        {
            Console.WriteLine(label
                + ": Player " + humanWins
                + " - Computer " + computerWins);
        }
    }
}