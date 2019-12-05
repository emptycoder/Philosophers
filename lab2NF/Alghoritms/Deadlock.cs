using Lab2.Entity;

namespace Lab2.Alghoritms
{
    class Deadlock : Alghoritm
    {
        public override string AlgName { get; } = "Deadlock alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            lock (philosopher.leftFork)
            {
                lock (philosopher.rightFork)
                {
                    if (!philosopher.hasLeftFork)
                    {
                        if (philosopher.leftFork.isFree())
                        {
                            philosopher.hasLeftFork = philosopher.leftFork.TakeFork();
                        }
                    }

                    if (!philosopher.hasRightFork)
                    {
                        if (philosopher.rightFork.isFree())
                        {
                            philosopher.hasRightFork = philosopher.rightFork.TakeFork();
                        }
                    }
                }
            }
            return true;
        }
    }
}
