namespace TicTacToe
{
    // Tolkar spelarens inmatning som en position på brädet.
    // Returnerar -1 och skriver ut ett felmeddelande om den är ogiltig
    public class PositionReader
    {
        public int Parse(string? input, Board board)
        {
            int position;
            if (!int.TryParse(input, out position))
            {
                Console.WriteLine(
                    "Invalid input. Enter a number between 1 and 9.");
                return -1;
            }

            if (position < 1 || position > 9)
            {
                Console.WriteLine("Invalid position. Try again.");
                return -1;
            }

            if (!board.IsEmpty(position))
            {
                Console.WriteLine("That position is already occupied.");
                return -1;
            }

            return position;
        }
    }
}