namespace TicTacToe
{
    // Kör matcher med samma inställningar tills spelaren inte vill
    // ha revansch. Skapar varje match via fabriken utan att veta
    // vilken sorts match det är
    public class SessionHost
    {
        private readonly IMatchFactory factory;

        public SessionHost(IMatchFactory factory)
        {
            this.factory = factory;
        }

        public void Run()
        {
            bool rematch = true;
            while (rematch)
            {
                //          FALL #9 (SessionHost.cs, IMatchFactory.cs, SingleMatchFactory.cs,
                //          TournamentFactory.cs, SingleMatch.cs, Tournament.cs):
                // VAD:     Factory Method pattern.
                // HUR:     SingleMatchFactory och TournamentFactory injiceras
                //          som IMatchFactory i SessionHost. Create() returnerar
                //          en ny SingleMatch eller Tournament som IMatch.
                // VARFÖR:  Varje revansch behöver en ny match, men
                //          SessionHost vet inte vilken sort. Fabriken har
                //          inställningar och end condition, så SessionHost
                //          kan skapa matcher utan att känna till dem.

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