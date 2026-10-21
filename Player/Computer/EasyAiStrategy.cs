namespace TicTacToe
{
    //  Easy väljer en slumpad ledig position
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