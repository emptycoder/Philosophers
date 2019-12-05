using Lab2.Entity;
using System.Threading;

namespace Lab2.Alghoritms
{
    public class SmartTable : Alghoritm
    {
        public override string AlgName { get; } = "Smart table alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            if (Monitor.TryEnter(table.forks))
            {
                if (philosopher.leftFork.isFree() && philosopher.rightFork.isFree())
                {
                    lock (philosopher.leftFork)
                    {
                        lock (philosopher.rightFork)
                        {
                            philosopher.leftFork.TakeFork();
                            philosopher.rightFork.TakeFork();
                            Monitor.Exit(table.forks);
                            philosopher.Eat();
                            return true;
                        }
                    }
                }
                else
                {
                    Monitor.Exit(table.forks);
                }
            }
            return false;
        }
    }
}
