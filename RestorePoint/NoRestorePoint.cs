namespace TicTacToe
{
    // Används i turneringar, där det vore fusk att gå tillbaka
    public class NoRestorePoint : IRestorePoint
    {
        public void Save(Board board)
        {
            Console.WriteLine("Restore points are not allowed in tournaments.");
        }

        public bool Load(Board board)
        {
            Console.WriteLine("Restore points are not allowed in tournaments.");
            return false;
        }
    }
}
