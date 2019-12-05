using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    class Livelock : Alghoritm
    {
        public override string AlgName { get; } = "Livelock alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            if (Monitor.TryEnter(philosopher.leftFork))
            {
                if (Monitor.TryEnter(philosopher.rightFork))
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
