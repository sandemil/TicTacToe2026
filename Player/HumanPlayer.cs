namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        private readonly IBoardStyle style;
        private readonly IRestorePoint restorePoint;
        private readonly PositionReader reader = new PositionReader();

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
                //          FALL #7 (HumanPlayer.cs, IRestorePoint.cs, FileRestorePoint.cs,
                //          NoRestorePoint.cs, Game.cs):
                // VAD:     Strategy pattern
                // HUR:     FileRestorePoint och NoRestorePoint
                //          injiceras som IRestorePoint i HumanPlayer.
                //          Save() och Load() anropas när spelaren
                //          skriver s eller l.
                // VARFÖR:  HumanPlayer behöver inte veta om det
                //          är en singelmatch eller turnering. Regeln
                //          att sparning inte får ske i turneringar
                //          ligger i NoRestorePoint (i stället för i
                //          en if-sats här i HumanPlayer).

                    restorePoint.Save(board);
                }
                else if (input == "l" && restorePoint.Load(board))
                {
                    style.Render(board);
                }
                else if (input != "l")
                {
                    int position = reader.Parse(input, board);
                    if (position != -1)
                    {
                        return position;
                    }
                }
            }
        }
    }
}