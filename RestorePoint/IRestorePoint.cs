namespace TicTacToe
{
    // Låter spelaren spara ställningen och senare gå tillbaka till den
    public interface IRestorePoint
    {
        void Save(Board board);

        // Returnerar true om brädet återställdes
        bool Load(Board board);
    }
}
