namespace TicTacToe
{
    //          FALL #1:
    // VAD:     Generics
    // HUR:     GameHistory<T> används som GameHistory<MoveRecord> för
    //          dragen i en match och som GameHistory<MatchResult> för
    //          alla matcher. Constraintet where T : IGameRecord behövs
    //          för att Print() ska kunna anropa Describe().
    // VARFÖR:  En klass lagrar både drag och resultat. Get() returnerar
    //          T, så Game kan läsa Winner från MatchResult utan casting.
    public class GameHistory<T> where T : IGameRecord
    {
        private readonly List<T> items = new List<T>();

        public int Count
        {
            get { return items.Count; }
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public T Get(int index)
        {
            return items[index];
        }

        public void Print()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].Describe());
            }
        }
    }
}
