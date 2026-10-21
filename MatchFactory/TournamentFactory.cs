namespace TicTacToe
{
    // Skapar en Tournament med det valda end conditionet
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
            return new Tournament(settings, endCondition);
        }
    }
}