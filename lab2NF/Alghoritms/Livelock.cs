using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    class Livelock : Alghoritm
    {
        public override string AlgName { get; } = "Livelock alghoritm";

        public override void TryEating(Philosopher philosopher)
        {
            if (Monitor.TryEnter(philosopher.leftFork, 30))
            {
                if (Monitor.TryEnter(philosopher.rightFork, 30))
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
