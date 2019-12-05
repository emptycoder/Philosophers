using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    class Timelock : Alghoritm
    {
        public override string AlgName { get; } = "Timelock alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            if (Monitor.TryEnter(philosopher.leftFork, philosopher.philosopherName * 10))
            {
                if (Monitor.TryEnter(philosopher.rightFork, philosopher.philosopherName * 10))
                {
                    philosopher.Eat();
                    Monitor.Exit(philosopher.rightFork);
                    Monitor.Exit(philosopher.leftFork);
                    return true;
                }
                else
                {
                    Monitor.Exit(philosopher.leftFork);
                }
            }
            return false;
        }
    }
}
