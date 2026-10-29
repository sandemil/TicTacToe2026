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

        // Frågar om inställningar, skapar spelarna och settings, 
        // samt låter SessionHost köra matcherna
        private void PlaySession()
        {
            IBoardStyle style = AskBoardStyle();
            IGameMode mode = AskGameMode();
            IAiStrategy strategy = AskStrategy();
            StartingPlayerRule startingRule = AskStartingRule();
            ISessionFactory sessionFactory = AskSessionType();

            IPlayer human = new HumanPlayer(
                'X',
                style,
                sessionFactory.CreateRestorePoint());
            IPlayer computer = new ComputerPlayer('O', strategy);

            MatchSettings settings = new MatchSettings(
                human,
                computer,
                mode,
                style,
                matchResults,
                strategy.Name,
                startingRule);

            SessionHost host = sessionFactory.CreateHost(settings);
            host.Run();
            PrintMatchHistory();
        }

        // Underliggande metoder använder sig av Menu<T> 
        // när de frågar om de olika inställningarna.
        private IBoardStyle AskBoardStyle()
        {
            Menu<IBoardStyle> menu =
                new Menu<IBoardStyle>("Choose board style:");
            menu.Add("Numbered", new NumberedBoard());
            menu.Add("Minimal", new MinimalBoard());
            return menu.Ask(); // returnerar en IBoardStyle
        }

        private IGameMode AskGameMode()
        {
            Menu<IGameMode> menu = new Menu<IGameMode>("Choose game mode:");
            menu.Add("Classic", new ClassicGameMode());
            menu.Add("Reverse", new ReverseGameMode());
            return menu.Ask(); // returnerar en IGameMode
        }

        private IAiStrategy AskStrategy()
        {
            Menu<IAiStrategy> menu =
                new Menu<IAiStrategy>("Choose difficulty:");
            menu.Add("Easy", new EasyAiStrategy());
            menu.Add("Medium", new MediumAiStrategy());
            menu.Add("Hard", new HardAiStrategy());
            return menu.Ask(); // returnerar en IAiStrategy
        }

        private StartingPlayerRule AskStartingRule()
        {
            Menu<StartingPlayerRule> menu =
                new Menu<StartingPlayerRule>("Who starts each round?");
            menu.Add("Player always starts", PlayerStarts);
            menu.Add("Computer always starts", ComputerStarts);
            menu.Add("Take turns", TakeTurns);
            return menu.Ask(); // returnerar en StartingPlayerRule
        }

        private IPlayer PlayerStarts(
            int round, IPlayer human, IPlayer computer)
        {
            return human;
        }

        private IPlayer ComputerStarts(
            int round, IPlayer human, IPlayer computer)
        {
            return computer;
        }

        private IPlayer TakeTurns(
            int round, IPlayer human, IPlayer computer)
        {
            if (round % 2 == 1)
            {
                return human;
            }
            return computer;
        }

        // Rätt fabrik ska returneras baserat på spelarens val
        private ISessionFactory AskSessionType()
        {
            Menu<ISessionFactory> menu =
                new Menu<ISessionFactory>("Choose match type:");
            menu.Add(
                "Single match (practice: s = save, l = load)",
                new SingleSessionFactory());
            menu.Add(
                "Tournament (several rounds, no save or load)",
                new TournamentSessionFactory());
            return menu.Ask();
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