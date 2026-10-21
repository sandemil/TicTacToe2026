namespace TicTacToe
{
    public interface IGameMode
    {
        string Name { get; }

        // GetWinningSymbol: vem har vunnit av X och O?
        char GetWinningSymbol(Board board);
    }
}