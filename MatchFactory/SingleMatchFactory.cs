namespace TicTacToe
{
    // Skapar en SingleMatch med nytt MoveRecord
    public class SingleMatchFactory : IMatchFactory
    {
        private readonly MatchSettings settings;

        public SingleMatchFactory(MatchSettings settings)
        {
            this.settings = settings;
        }

        public IMatch Create()
        {
            GameHistory<MoveRecord> moves = new GameHistory<MoveRecord>();
            return new SingleMatch(settings, moves);
        }
    }
}