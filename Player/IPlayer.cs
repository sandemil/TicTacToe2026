namespace TicTacToe
{
    public interface IPlayer
    {
        char Symbol { get; }
        string Name { get; }

        int ChooseMove(Board board, IGameMode mode);
    }
}