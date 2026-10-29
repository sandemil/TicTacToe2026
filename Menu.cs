namespace TicTacToe
{
    //          FALL #2: (Menu.cs och Game.cs)
    // VAD:     Generics
    // HUR:     Menu<T> kopplar varje menytext till ett värde av typen T och
    //          Ask() returnerar värdet som spelaren väljer. Den används till
    //          att välja t.ex. speltyp, svårighetsgrad och vem som börjar. 
    // VARFÖR:  All logik för att visa alternativ och läsa in ett giltigt
    //          val finns på ett ställe i stället för i varje meny. Ask()
    //          returnerar T, så Game får rätt typ direkt utan att behöva casta.
    public class Menu<T>
    {
        private readonly string title;
        private readonly List<string> labels = new List<string>();
        private readonly List<T> values = new List<T>();

        public Menu(string title)
        {
            this.title = title;
        }

        public void Add(string label, T value)
        {
            labels.Add(label);
            values.Add(value);
        }

        // Visar alternativen och returnerar det som användaren väljer
        public T Ask()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(title);
                for (int i = 0; i < labels.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + labels[i]);
                }
                Console.Write("Choose an option: ");

                int choice;
                bool valid = int.TryParse(Console.ReadLine(), out choice);
                if (valid && choice >= 1 && choice <= labels.Count)
                {
                    return values[choice - 1];
                }

                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}