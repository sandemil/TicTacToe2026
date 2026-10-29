namespace TicTacToe
{
    //          FALL #10:
    // VAD:     Generics med constraint.
    // HUR:     GameHistory<T> konstrueras som GameHistory<MatchResult> i Game
    //          och som GameHistory<MoveRecord> i Board. Constrainten
    //          T : IGameRecord behövs för att Print() ska kunna anropa
    //          Describe().
    // VARFÖR:  En och samma klass lagrar både matchresultat och drag, i
    //          stället för två nästan likadana klasser. Get() returnerar T,
    //          så typinformationen behålls: Game läser Winner och
    //          FileRestorePoint läser Symbol och Position utan att behöva casta.
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
