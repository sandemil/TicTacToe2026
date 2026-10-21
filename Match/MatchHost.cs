using System;

namespace TicTacToe
{
    // Kör matcher med samma inställningar tills spelaren inte vill
    // ha revansch. Skapar varje match via fabriken utan att veta
    // vilken sorts match det är.
    public class MatchHost
    {
        private readonly IMatchFactory factory;

        public MatchHost(IMatchFactory factory)
        {
            this.factory = factory;
        }

        public void Run()
        {
            bool rematch = true;
            while (rematch)
            {
                IMatch match = factory.Create();
                match.Play();
                rematch = AskRematch();
            }
        }

        private bool AskRematch()
        {
            while (true)
            {
                Console.Write("Rematch with the same settings? (y/n): ");
                string? answer = Console.ReadLine();
                if (answer == null)
                {
                    return false;
                }

                answer = answer.Trim().ToLower();
                if (answer == "y")
                {
                    return true;
                }
                if (answer == "n")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Enter y or n.");
            }
        }
    }
}