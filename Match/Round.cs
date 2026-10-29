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
            TurnOrder turns = new TurnOrder(settings, number);
            GameStatus referee = new GameStatus(settings);

            Console.WriteLine();
            Console.WriteLine("You are X. Computer is O.");
            Console.WriteLine(turns.GetCurrent().Name + " starts.");
            settings.Style.Render(board);

            while (true)
            {
                IPlayer current = turns.GetCurrent();
                //          FALL #3:
                // VAD:     Strategy pattern
                // HUR:     HumanPlayer och ComputerPlayer injiceras
                //          som IPlayer via MatchSettings. Round anropar
                //          ChooseMove() på den spelare som har turen.
                // VARFÖR:  Round behandlar båda spelarna likadant (det
                //          behövs ingen if-sats för människa eller
                //          dator). En ny sorts spelare kan läggas till
                //          utan att Round ändras.
                int move = current.ChooseMove(board, settings.Mode);
                board.Play(move, current.Symbol);

                //          FALL #5:
                // VAD:     Strategy pattern
                // HUR:     NumberedBoard och MinimalBoard injiceras som
                //          IBoardStyle via MatchSettings. Round anropar
                //          Render() varje gång brädet ska visas.
                // VARFÖR:  Round vet inte hur brädet ritas, vilket gör
                //          att en ny stil kan läggas till utan att Round
                //          eller Board ändras.
                settings.Style.Render(board);

                string? result = referee.Judge(board);
                if (result != null)
                {
                    return result;
                }

                turns.Switch();
            }
        }
    }
}