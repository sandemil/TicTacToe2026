namespace TicTacToe
{
    // Skapar en Tournament med nytt MoveRecord, samt det valda end conditionet
    public class TournamentFactory : IMatchFactory
    {
        private readonly MatchSettings settings;
        private readonly ITournamentEndCondition endCondition;

        public TournamentFactory(
            MatchSettings settings,
            ITournamentEndCondition endCondition)
        {
            this.settings = settings;
            this.endCondition = endCondition;
        }

        public IMatch Create()
        {
            GameHistory<MoveRecord> moves = new GameHistory<MoveRecord>();
            return new Tournament(settings, moves, endCondition);
        }
    }
}