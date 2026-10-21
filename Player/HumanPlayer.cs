namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        private readonly IBoardStyle style;
        private readonly IRestorePoint restorePoint;

        public char Symbol { get; }
        public string Name { get; }

        public HumanPlayer(
            char symbol,
            IBoardStyle style,
            IRestorePoint restorePoint)
        {
            Symbol = symbol;
            Name = "Player";
            this.style = style;
            this.restorePoint = restorePoint;
        }

        public int ChooseMove(Board board, IGameMode mode)
        {
            while (true)
            {
                Console.Write("Choose position (1-9): ");
                string? input = Console.ReadLine();

                if (input == "s")
                {
                    restorePoint.Save(board);
                    continue;
                }

                if (input == "l")
                {
                    if (restorePoint.Load(board))
                    {
                        style.Render(board);
                    }
                    continue;
                }

                int position;
                if (!int.TryParse(input, out position))
                {
                    Console.WriteLine(
                        "Invalid input. Enter a number between 1 and 9.");
                    continue;
                }

                if (position < 1 || position > 9)
                {
                    Console.WriteLine("Invalid position. Try again.");
                    continue;
                }

                if (!board.IsEmpty(position))
                {
                    Console.WriteLine("That position is already occupied.");
                    continue;
                }

                return position;
            }
        }
    }
}