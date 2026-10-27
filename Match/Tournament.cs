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
            Scoreboard score = new Scoreboard(settings);
            do
            {
                Round round = new Round(settings, score.StartRound());
                score.Record(round.Play());
            }
            while (!score.IsFinished(endCondition));

            score.PrintResult();
            settings.Results.Add(new MatchResult(
                score.GetWinner(),
                settings.Difficulty,
                settings.Mode.Name,
                endCondition.Name));
        }
    }
}