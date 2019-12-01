using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    class Timelock : Alghoritm
    {
        public override string AlgName { get; } = "Timelock alghoritm";

        public override void TryEating(Philosopher philosopher)
        {
            if (Monitor.TryEnter(philosopher.leftFork, 30))
            {
                if (Monitor.TryEnter(philosopher.rightFork, 2))
                {
                    philosopher.Eat();
                    Monitor.Exit(philosopher.rightFork);
                    Monitor.Exit(philosopher.leftFork);
                }
                else
                {
                    Monitor.Exit(philosopher.leftFork);
                }
            }
        }
    }
}
