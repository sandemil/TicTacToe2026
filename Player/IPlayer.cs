namespace TicTacToe
{
    public interface IPlayer
    {
        char Symbol { get; }
        string Name { get; }

        // Nästa drag
        int ChooseMove(Board board, IGameMode mode); // Fall #3
    }
}