namespace TicTacToe
{
    // Avgör efter varje drag om rundan är vunnen eller oavgjord
    public class GameStatus
    {
        private readonly MatchSettings settings;

        public GameStatus(MatchSettings settings)
        {
            this.settings = settings;
        }

        // Returnerar vinnarens namn, "Draw", eller null om rundan
        // ska fortsätta
        public string? Judge(Board board)
        {
            //          FALL #4: (GameStatus.cs, IGameMode.cs, ClassicGameMode.cs,
            //          ReverseGameMode.cs, MatchSettings.cs, Game.cs)
            // VAD:     Strategy pattern
            // HUR:     ClassicGameMode och ReverseGameMode injiceras
            //          som IGameMode via MatchSettings. GameStatus
            //          anropar GetWinningSymbol() för att avgöra vem
            //          som vann.
            // VARFÖR:  Reglerna för vinst ligger i varsin klass (i
            //          stället för i if-satser i GameStatus). Ett nytt
            //          spelläge kan läggas till utan att GameStatus
            //          eller Round ändras.
            char winnerSymbol = settings.Mode.GetWinningSymbol(board);
            if (winnerSymbol != ' ')
            {
                string winnerName = GetNameFor(winnerSymbol);
                Console.WriteLine(winnerName + " wins the round!");
                return winnerName;
            }

            if (board.IsFull())
            {
                Console.WriteLine("It's a draw!");
                return "Draw";
            }

            return null;
        }

        public string GetNameFor(char symbol)
        {
            if (symbol == settings.Human.Symbol)
            {
                return settings.Human.Name;
            }

            return settings.Computer.Name;
        }
    }
}