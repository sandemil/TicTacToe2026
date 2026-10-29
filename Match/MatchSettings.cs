namespace TicTacToe
{
    // Samlar allt som väljs i menyerna så att det kan skickas
    // runt som ett objekt i stället för många parametrar
    public class MatchSettings
    {
        public IPlayer Human { get; }
        public IPlayer Computer { get; }
        public IGameMode Mode { get; } // FALL #4
        public IBoardStyle Style { get; } // FALL #5
        public GameHistory<MatchResult> Results { get; }
        public string Difficulty { get; }
        public StartingPlayerRule StartingPlayer { get; } // FALL #8

        public MatchSettings(
            IPlayer human,
            IPlayer computer,
            IGameMode mode,
            IBoardStyle style,
            GameHistory<MatchResult> results,
            string difficulty,
            StartingPlayerRule startingPlayer)
        {
            Human = human;
            Computer = computer;
            Mode = mode;
            Style = style;
            Results = results;
            Difficulty = difficulty;
            StartingPlayer = startingPlayer;
        }
    }
}