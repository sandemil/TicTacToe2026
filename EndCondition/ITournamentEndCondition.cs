namespace TicTacToe
{
    public interface ITournamentEndCondition
    {
        string Name { get; }

        bool IsFinished(int humanWins, int computerWins, int roundsPlayed);
    }
}