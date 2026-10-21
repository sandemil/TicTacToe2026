using System;

namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public char Symbol { get; }
        public string Name { get; }

        public HumanPlayer(char symbol)
        {
            Symbol = symbol;
            Name = "Player";
        }

        public int ChooseMove(Board board, IGameMode mode)
        {
            while (true)
            {
                Console.Write("Choose position (1-9): ");
                string? input = Console.ReadLine();

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