namespace TicTacToe
{
    // Sparar dragen i en textfil, ett drag per rad (t.ex. "X 5").
    // Filen finns kvar efter att programmet avslutats, så en sparad
    // ställning kan laddas även i nästa körning
    public class FileRestorePoint : IRestorePoint
    {
        private readonly string path;

        public FileRestorePoint(string path)
        {
            this.path = path;
        }

        public void Save(Board board)
        {
            List<string> lines = new List<string>();
            GameHistory<MoveRecord> moves = board.Moves;
            for (int i = 0; i < moves.Count; i++)
            {
                MoveRecord move = moves.Get(i);
                lines.Add(move.Symbol + " " + move.Position);
            }

            File.WriteAllLines(path, lines);
            Console.WriteLine("Restore point saved.");
        }

        public bool Load(Board board)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("No restore point saved yet.");
                return false;
            }

            GameHistory<MoveRecord> saved = new GameHistory<MoveRecord>();
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                char symbol = lines[i][0];
                int position = int.Parse(lines[i].Substring(2));
                saved.Add(new MoveRecord(symbol, position));
            }

            board.Restore(saved);
            Console.WriteLine("Restore point loaded.");
            return true;
        }
    }
}
