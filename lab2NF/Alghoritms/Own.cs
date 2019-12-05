using Lab2.Entity;

namespace Lab2.Alghoritms
{
    public class Own : Alghoritm
    {
        public override string AlgName { get; } = "Own alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            lock(table.forks)
            {
                if (philosopher.leftFork.isFree() && philosopher.rightFork.isFree())
                {
                    philosopher.hasLeftFork = philosopher.leftFork.TakeFork();
                    philosopher.hasRightFork = philosopher.rightFork.TakeFork();
                    philosopher.Eat();
                    return true;
                }
                return false;
            }
        }
    }
}
