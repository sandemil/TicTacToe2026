using System;

namespace TicTacToe
{
    // En match med endast en runda
    public class SingleMatch : IMatch
    {
        private readonly MatchSettings settings;
        private readonly GameHistory<MoveRecord> moves;

        public SingleMatch(
            MatchSettings settings,
            GameHistory<MoveRecord> moves)
        {
            this.settings = settings;
            this.moves = moves;
        }

        public void Play()
        {
            Round round = new Round(settings, moves, 1);
            string winner = round.Play();

            if (winner == "Draw")
            {
                Console.WriteLine("The match ended in a draw.");
            }
            else
            {
                Console.WriteLine(winner + " wins the match!");
            }

            settings.Results.Add(new MatchResult(
                winner,
                settings.Difficulty,
                settings.Mode.Name,
                "Single match"));

            Console.WriteLine();
            Console.WriteLine("Moves this match:");
            moves.Print();
        }
    }
}