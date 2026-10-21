namespace TicTacToe
{
    // Turnering: flera rundor med poängställning. Frågar efter end
    // condition och tillåter inga återställningspunkter
    public class TournamentSessionFactory : ISessionFactory
    {
        public IRestorePoint CreateRestorePoint()
        {
            return new NoRestorePoint();
        }

        public SessionHost CreateHost(MatchSettings settings)
        {
            ITournamentEndCondition condition = AskEndCondition();
            return new SessionHost(new TournamentFactory(settings, condition));
        }

        // Användaren väljer vilket end condition som ska gälla:
        //   - best of x
        //   - first to x
        //   - tills användaren avslutar spelet
        private ITournamentEndCondition AskEndCondition()
        {
            Menu<string> menu = new Menu<string>("Choose tournament type:");
            menu.Add("Best of X", "best");
            menu.Add("First to X", "first");
            menu.Add("Until you quit", "quit");

            string choice = menu.Ask();

            switch (choice)
            {
                case "best":
                    return new BestOfX(AskNumber("Best of how many rounds?"));
                case "first":
                    return new FirstToX(AskNumber("First to how many wins?"));
                default:
                    return new UntilPlayerQuits();
            }
        }

        private int AskNumber(string question)
        {
            while (true)
            {
                Console.Write(question + " ");
                int number;
                if (int.TryParse(Console.ReadLine(), out number) && number >= 1)
                {
                    return number;
                }

                Console.WriteLine("Please enter a number of at least 1.");
            }
        }
    }
}
