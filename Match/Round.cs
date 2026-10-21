using System;

namespace TicTacToe
{
    // Spelar en runda på ett nytt bräde och returnerar vinnarens
    // namn, eller "Draw" om det blir oavgjort.
    public class Round
    {
        private readonly MatchSettings settings;
        private readonly GameHistory<MoveRecord> moves;
        private readonly int number;

        public Round(
            MatchSettings settings,
            GameHistory<MoveRecord> moves,
            int number)
        {
            this.settings = settings;
            this.moves = moves;
            this.number = number;
        }

        public string Play()
        {
            Board board = new Board();
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
                int move = current.ChooseMove(board, settings.Mode);
                board.Place(move, current.Symbol);
                moves.Add(new MoveRecord(current.Symbol, move));

                char winnerSymbol = settings.Mode.GetWinningSymbol(board);
                if (winnerSymbol != ' ')
                {
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