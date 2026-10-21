namespace TicTacToe
{
    public interface IAiStrategy
    {
        string Name { get; }

        // Olika val av moves beroende på svårighetsgrad
        int ChooseMove(Board board, IGameMode mode, char symbol);
    }
}