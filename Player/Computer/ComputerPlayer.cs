namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        private readonly IAiStrategy strategy;

        public char Symbol { get; }
        public string Name { get; }

        public ComputerPlayer(char symbol, IAiStrategy strategy)
        {
            Symbol = symbol;
            Name = "Computer";
            this.strategy = strategy;
        }

        // Låter AI välja drag baserat på vald svårighetsgrad
        public int ChooseMove(Board board, IGameMode mode)
        {
            int move = strategy.ChooseMove(board, mode, Symbol);
            Console.WriteLine("Computer chooses position " + move);
            return move;
        }
    }
}