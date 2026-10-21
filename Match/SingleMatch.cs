namespace TicTacToe
{
    // En match med endast en runda
    public class SingleMatch : IMatch
    {
        private readonly MatchSettings settings;

        public SingleMatch(MatchSettings settings)
        {
            this.settings = settings;
        }

        public void Play()
        {
            Round round = new Round(settings, 1);
            string winner = round.Play();

            if (winner == "Draw")
            {
                Console.WriteLine("The match ended in a draw.");
            }
            else
            {
                Console.WriteLine(winner + " wins the match!");
            }

            settings.Results.Add(new MatchResult(
                winner,
                settings.Difficulty,
                settings.Mode.Name,
                "Single match"));
        }
    }
}