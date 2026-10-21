namespace TicTacToe
{
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