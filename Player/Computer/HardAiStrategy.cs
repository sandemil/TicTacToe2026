using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class HardAiStrategy : IAiStrategy
    {
        private readonly Random random = new Random();

        public string Name
        {
            get { return "Hard"; }
        }

        public int ChooseMove(Board board, IGameMode mode, char symbol)
        {
            char opponent = GetOpponent(symbol);

            int winningMove = FindWinningMove(board, mode, symbol);
            if (winningMove != -1)
            {
                return winningMove;
            }

            int blockingMove = FindWinningMove(board, mode, opponent);
            if (blockingMove != -1)
            {
                return blockingMove;
            }

            List<int> safeMoves = FindSafeMoves(board, mode, symbol);
            if (safeMoves.Contains(5))
            {
                return 5;
            }

            int corner = ChooseRandomCorner(safeMoves);
            if (corner != -1)
            {
                return corner;
            }

            int index = random.Next(safeMoves.Count);
            return safeMoves[index];
        }

        private int ChooseRandomCorner(List<int> candidates)
        {
            int[] corners = { 1, 3, 7, 9 };
            List<int> available = new List<int>();
            for (int i = 0; i < corners.Length; i++)
            {
                if (candidates.Contains(corners[i]))
                {
                    available.Add(corners[i]);
                }
            }

            if (available.Count == 0)
            {
                return -1;
            }

            int index = random.Next(available.Count);
            return available[index];
        }

        private char GetOpponent(char symbol)
        {
            if (symbol == 'X')
            {
                return 'O';
            }
            return 'X';
        }

        private int FindWinningMove(
            Board board,
            IGameMode mode,
            char symbol)
        {
            List<int> empty = board.GetEmptyPositions();
            for (int i = 0; i < empty.Count; i++)
            {
                int position = empty[i];
                board.Place(position, symbol);
                char winner = mode.GetWinningSymbol(board);
                board.Clear(position);
                if (winner == symbol)
                {
                    return position;
                }
            }
            return -1;
        }

        private List<int> FindSafeMoves(
            Board board,
            IGameMode mode,
            char symbol)
        {
            char opponent = GetOpponent(symbol);
            List<int> empty = board.GetEmptyPositions();
            List<int> safe = new List<int>();
            for (int i = 0; i < empty.Count; i++)
            {
                int position = empty[i];
                board.Place(position, symbol);
                char winner = mode.GetWinningSymbol(board);
                board.Clear(position);
                if (winner != opponent)
                {
                    safe.Add(position);
                }
            }

            if (safe.Count == 0)
            {
                return empty;
            }
            return safe;
        }
    }
}