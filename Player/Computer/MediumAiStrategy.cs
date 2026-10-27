// AI-genererad kod

namespace TicTacToe
{
    public class MediumAiStrategy : IAiStrategy
    {
        private readonly Random random = new Random();

        public string Name
        {
            get { return "Medium"; }
        }

        // Om möjligt vinner den, annars blockerar den 
        // och väljer i sista hand ett säkert drag
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
            int index = random.Next(safeMoves.Count);
            return safeMoves[index];
        }

        private char GetOpponent(char symbol)
        {
            if (symbol == 'X')
            {
                return 'O';
            }
            return 'X';
        }

        // Testar varje ledig ruta och returnerar den som ger vinst om möjligt
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

        // Returnerar de lediga rutor som inte ger motståndaren en vinst
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