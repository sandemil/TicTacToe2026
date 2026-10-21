namespace TicTacToe
{
    public class UntilPlayerQuits : ITournamentEndCondition
    {
        public string Name
        {
            get { return "Until quit"; }
        }

        // frågar spelaren om en till runda, om nej så returneras true
        public bool IsFinished(int humanWins, int computerWins, int roundsPlayed)
        {
            while (true)
            {
                Console.Write("Play another round? (y/n): ");
                string? answer = Console.ReadLine();
                if (answer == null)
                {
                    return true;
                }

                answer = answer.Trim().ToLower();
                if (answer == "y")
                {
                    return false;
                }
                if (answer == "n")
                {
                    return true;
                }

                Console.WriteLine("Invalid input. Enter y or n.");
            }
        }
    }
}