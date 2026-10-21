namespace TicTacToe
{
    public class MatchResult : IGameRecord
    {
        public string Winner { get; }
        public string Difficulty { get; }
        public string ModeName { get; }
        public string MatchType { get; }

        public MatchResult(
            string winner,
            string difficulty,
            string modeName,
            string matchType)
        {
            Winner = winner;
            Difficulty = difficulty;
            ModeName = modeName;
            MatchType = matchType;
        }

        public string Describe()
        {
            string ending;
            if (Winner == "Draw")
            {
                ending = "Draw";
            }
            else
            {
                ending = Winner + " won";
            }

            return ending
                + " ("
                + MatchType
                + ", "
                + ModeName
                + ", "
                + Difficulty
                + ")";
        }
    }
}
