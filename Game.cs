namespace TicTacToe
{
    public class Game
    {
        private readonly GameHistory<MatchResult> matchResults =
            new GameHistory<MatchResult>();

        public void Run()
        {
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine("       TIC-TAC-TOE");
            Console.WriteLine("=========================");

            Menu<bool> mainMenu = new Menu<bool>("Main menu:");
            mainMenu.Add("Play", true);
            mainMenu.Add("Exit", false);

            while (mainMenu.Ask())
            {
                PlaySession();
            }

            Console.WriteLine("Thank you for playing. Goodbye!");
        }

        // Frågar om inställningar, skapar spelarna och settings, samt låter MatchHost köra matcherna
        private void PlaySession()
        {
            IBoardStyle style = AskBoardStyle();
            IGameMode mode = AskGameMode();
            IAiStrategy strategy = AskStrategy();
            StartingPlayerRule startingRule = AskStartingRule();

            IPlayer human = new HumanPlayer('X');
            IPlayer computer = new ComputerPlayer('O', strategy);

            MatchSettings settings = new MatchSettings(
                human,
                computer,
                mode,
                style,
                matchResults,
                strategy.Name,
                startingRule);

            IMatchFactory factory = AskMatchFactory(settings);

            MatchHost host = new MatchHost(factory);
            host.Run();
            PrintMatchHistory();
        }

        // Underliggande metoder använder sig av Menu<T> när de frågar om de olika inställningarna.
        private IBoardStyle AskBoardStyle()
        {
            Menu<IBoardStyle> menu =
                new Menu<IBoardStyle>("Choose board style:");
            menu.Add("Numbered", new NumberedBoard());
            menu.Add("Minimal", new MinimalBoard());
            return menu.Ask();
        }

        private IGameMode AskGameMode()
        {
            Menu<IGameMode> menu = new Menu<IGameMode>("Choose game mode:");
            menu.Add("Classic", new ClassicGameMode());
            menu.Add("Reverse", new ReverseGameMode());
            return menu.Ask();
        }

        private IAiStrategy AskStrategy()
        {
            Menu<IAiStrategy> menu =
                new Menu<IAiStrategy>("Choose difficulty:");
            menu.Add("Easy", new EasyAiStrategy());
            menu.Add("Medium", new MediumAiStrategy());
            menu.Add("Hard", new HardAiStrategy());
            return menu.Ask();
        }

        private StartingPlayerRule AskStartingRule()
        {
            Menu<StartingPlayerRule> menu =
                new Menu<StartingPlayerRule>("Who starts each round?");
            menu.Add("Player always starts", PlayerStarts);
            menu.Add("Computer always starts", ComputerStarts);
            menu.Add("Take turns", TakeTurns);
            return menu.Ask();
        }

        private IPlayer PlayerStarts(int round, IPlayer human, IPlayer computer)
        {
            return human;
        }

        private IPlayer ComputerStarts(int round, IPlayer human, IPlayer computer)
        {
            return computer;
        }

        private IPlayer TakeTurns(int round, IPlayer human, IPlayer computer)
        {
            if (round % 2 == 1)
            {
                return human;
            }
            return computer;
        }

        // Rätt fabrik ska returneras baserat på spelarens val
        private IMatchFactory AskMatchFactory(MatchSettings settings)
        {
            Menu<bool> menu = new Menu<bool>("Choose match type:");
            menu.Add("Single match", false);
            menu.Add("Tournament", true);

            // Om användaren kör SingleMatch
            if (!menu.Ask())
            {
                return new SingleMatchFactory(settings);
            }

            // Om användaren kör Tournament
            ITournamentEndCondition condition = AskEndCondition();
            return new TournamentFactory(settings, condition);
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

        private void PrintMatchHistory()
        {
            Console.WriteLine();
            Console.WriteLine("Completed matches:");
            matchResults.Print();

            if (matchResults.Count > 0)
            {
                MatchResult latest =
                    matchResults.Get(matchResults.Count - 1);
                Console.WriteLine("Latest result: " + latest.Winner);
            }
        }
    }
}