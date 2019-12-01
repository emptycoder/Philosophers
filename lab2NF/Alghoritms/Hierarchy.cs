using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    public class Hierarchy : Alghoritm
    {
        public override string AlgName { get; } = "Hierarchy table alghoritm";

        public override void TryEating(Philosopher philosopher)
        {
            if (philosopher.leftFork.ForkNumber < philosopher.rightFork.ForkNumber)
            {
                if (Monitor.TryEnter(philosopher.leftFork))
                {
                    if (Monitor.TryEnter(philosopher.rightFork))
                    {
                        philosopher.Eat();
                        Monitor.Exit(philosopher.rightFork);
                        Monitor.Exit(philosopher.leftFork);
                    }
                }
            }
            else
            {
                if (Monitor.TryEnter(philosopher.rightFork))
                {
                    if (Monitor.TryEnter(philosopher.leftFork))
                    {
                        philosopher.Eat();
                        Monitor.Exit(philosopher.leftFork);
                        Monitor.Exit(philosopher.rightFork);
                    }
                }
            }
        }
    }
}
