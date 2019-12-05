using Lab2.Entity;
using Lab2.Tools;
using System;
using System.Threading;

namespace Lab2.Alghoritms
{
    public abstract class Alghoritm
    {
        public virtual string AlgName { get; }
        protected Table table;

        public virtual bool TryEating(Philosopher philosopher) { return false; }

        public void Thinking(Philosopher philosopher)
        {
            while (true)
            {
                if (TryEating(philosopher))
                {
                    Thread.Sleep(Program.TimeForWaiting);
                }
            }
        }

        public string Execute(Table table)
        {
            this.table = table;
            GC.Collect();
            TaskHelper.For((i) => Thinking(table.philosophers[i]));

            return $"{AlgName}\n{table.ToString()}";
        }
    }
}
