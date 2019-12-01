using System.Text;

namespace Lab2.Entity
{
    public class Table
    {
        public Fork[] forks { get; }
        public Philosopher[] philosophers { get; }

        public Table()
        {
            forks = new Fork[Program.ThreadsCount];
            for (int i = 0; i < Program.ThreadsCount; i++)
            {
                forks[i] = new Fork(i);
            }

            philosophers = new Philosopher[Program.ThreadsCount];
            for (int i = 0; i < Program.ThreadsCount; i++)
            {
                philosophers[i] = new Philosopher(forks[i], forks[(i + 1) % Program.ThreadsCount], i);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            uint countOfEatenFood = 0;
            foreach (var philosopher in philosophers)
            {
                countOfEatenFood += philosopher.GetAmountEaten();
                result.Append(philosopher.ToString());
            }

            result.Append("\nCount of eaten food: ");
            result.Append(countOfEatenFood);

            return result.ToString();
        }
    }
}
