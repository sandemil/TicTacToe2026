namespace TicTacToe
{
    // Spelar en runda på ett nytt board och returnerar vinnarens
    // namn, eller "Draw" om det blir oavgjort
    public class Round
    {
        private readonly MatchSettings settings;
        private readonly int number;

        public Round(MatchSettings settings, int number)
        {
            this.settings = settings;
            this.number = number;
        }

        public string Play()
        {
            Board board = new Board();
            //          FALL #8:
            //  VAD:    Delegater och beroendeinjektion
            //  HUR:    Game har tre metoder med samma signatur som delegaten
            //          StartingPlayerRule: PlayerStarts, ComputerStarts och
            //          TakeTurns. Den som börjar väljs genom att delegaten 
            //          injiceras i MatchSettings och anropas här.
            // VARFÖR:  Round behöver inte veta hur startspelaren väljs.
            //          Varje regel är en egen metod i stället för if-satser,
            //          och en ny regel läggs till med en metod och ett menyval.
            IPlayer current = settings.StartingPlayer(
                number,
                settings.Human,
                settings.Computer);

            Console.WriteLine();
            Console.WriteLine("You are X. Computer is O.");
            Console.WriteLine(current.Name + " starts.");

            while (true)
            {
                settings.Style.Render(board);
                //          FALL #3:
                // VAD:     Strategy pattern
                // HUR:     HumanPlayer och ComputerPlayer injiceras som
                //          IPlayer via MatchSettings. Round anropar
                //          ChooseMove() på den spelare som har turen.
                // VARFÖR:  Round behandlar båda spelarna likadant (det behövs
                //          ingen if-sats för människa eller dator).
                //          En ny sorts spelare kan läggas till utan att
                //          Round ändras.
                int move = current.ChooseMove(board, settings.Mode);
                board.Play(move, current.Symbol);

                //          FALL #4:
                // VAD:     Strategy pattern
                // HUR:     ClassicGameMode och ReverseGameMode injiceras som
                //          IGameMode via MatchSettings. Round anropar
                //          GetWinningSymbol() för att avgöra vem som vann.
                // VARFÖR:  Reglerna för vinst ligger i varsin klass (i
                //          stället för i if-satser i Round). Ett nytt spelläge
                //          kan läggas till utan att Round ändras.
                char winnerSymbol = settings.Mode.GetWinningSymbol(board);
                if (winnerSymbol != ' ')
                {
                //          FALL #5:
                // VAD:     Strategy pattern
                // HUR:     NumberedBoard och MinimalBoard injiceras som
                //          IBoardStyle via MatchSettings. Round anropar
                //          Render() varje gång brädet ska visas.
                // VARFÖR:  Round  vet inte hur brädet ritas, vilket gör att en ny
                //          stil kan läggas till utan att Round eller Board ändras.
                    settings.Style.Render(board);
                    string winnerName = GetNameFor(winnerSymbol);
                    Console.WriteLine(winnerName + " wins the round!");
                    return winnerName;
                }

                if (board.IsFull())
                {
                    settings.Style.Render(board);
                    Console.WriteLine("It's a draw!");
                    return "Draw";
                }

                if (current == settings.Human)
                {
                    current = settings.Computer;
                }
                else
                {
                    current = settings.Human;
                }
            }
        }

        private string GetNameFor(char symbol)
        {
            if (symbol == settings.Human.Symbol)
            {
                return settings.Human.Name;
            }

            return settings.Computer.Name;
        }
    }
}