namespace TicTacToe
{
    // Varje matchtyp har en egen SessionFactory som bestämmer
    // reglerna för sessionen
    public interface ISessionFactory
    {
        IRestorePoint CreateRestorePoint();

        SessionHost CreateHost(MatchSettings settings);
    }
}
