using System;
using System.Collections.Generic;

namespace TicTacToe
{
    //          FALL #6:
    // VAD:     Generics, en egen generisk typ.
    // HUR:     Menu<T> visar numrerade alternativ och returnerar det
    //          värde som hör till valet. Game använder den med fem
    //          typargument: IBoardRenderer, GameMode, IAiStrategy,
    //          StartingPlayerRule och MatchFactory.
    // VARFÖR:  En klass ersätter fyra nästan identiska menymetoder,
    //          och Ask() returnerar rätt typ direkt utan casting.
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