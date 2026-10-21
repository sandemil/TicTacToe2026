namespace TicTacToe
{
    // Enkel match: en runda där spelaren kan spara ställningen och
    // ladda den igen, även i en senare körning
    public class SingleSessionFactory : ISessionFactory
    {
        private const string SaveFilePath = "savegame.txt";

        public IRestorePoint CreateRestorePoint()
        {
            return new FileRestorePoint(SaveFilePath);
        }

        public SessionHost CreateHost(MatchSettings settings)
        {
            return new SessionHost(new SingleMatchFactory(settings));
        }
    }
}
