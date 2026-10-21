using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class EasyAiStrategy : IAiStrategy
    {
        private readonly Random random = new Random();

        public string Name
        {
            get { return "Easy"; }
        }

        public int ChooseMove(Board board, IGameMode mode, char symbol)
        {
            List<int> empty = board.GetEmptyPositions();
            int index = random.Next(empty.Count);
            return empty[index];
        }
    }
}