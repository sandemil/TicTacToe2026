namespace TicTacToe
{
    // Olika end conditions beroende på vad spelaren väljer
    public interface ITournamentEndCondition
    {
        string Name { get; }

        bool IsFinished(int humanWins, int computerWins, int roundsPlayed);
    }
}