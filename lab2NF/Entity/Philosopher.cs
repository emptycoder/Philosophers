using System;
using System.Threading;

namespace Lab2.Entity
{
    public class Philosopher
    {
        public Fork leftFork { get; }
        public Fork rightFork { get; }

        public bool hasLeftFork;
        public bool hasRightFork;

        public int philosopherName { get; }
        private uint _amountEaten = 0;

        public Philosopher(Fork leftFork, Fork rightFork, int philosopherName)
        {
            this.leftFork = leftFork;
            this.rightFork = rightFork;
            this.hasLeftFork = false;
            this.hasRightFork = false;
            this.philosopherName = philosopherName;
        }

        public uint GetAmountEaten()
        {
            return _amountEaten;
        }

        public void Eat()
        {
            _amountEaten++;
            Thread.Sleep(Program.TimeForEating);
            leftFork.ReturnFork();
            rightFork.ReturnFork();
        }

        public void ResetAmountEaten()
        {
            _amountEaten = 0;
        }

        public override string ToString()
        {
            return $"{philosopherName}: {_amountEaten}\n";
        }
    }
}
