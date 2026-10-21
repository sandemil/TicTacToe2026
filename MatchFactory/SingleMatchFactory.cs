namespace TicTacToe
{
    // Skapar en SingleMatch
    public class SingleMatchFactory : IMatchFactory
    {
        private readonly MatchSettings settings;

        public SingleMatchFactory(MatchSettings settings)
        {
            this.settings = settings;
        }

        public IMatch Create()
        {
            return new SingleMatch(settings);
        }
    }
}