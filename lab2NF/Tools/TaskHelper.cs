using System;
using System.Threading;

namespace Lab2.Tools
{
    static class TaskHelper
    {
        private static Thread[] threads;
        public static void For(Action<int> action)
        {
            threads = new Thread[Program.ThreadsCount];
            for (int i = 0; i < Program.ThreadsCount; i++)
            {
                threads[i] = new Thread(Caller);
            }

            for (int i = 0; i < Program.ThreadsCount; i++)
            {
                threads[i].Start(new TaskName(action, i));
            }

            Thread.Sleep(Program.MaxWorkingTime);
            KillAll();
        }

        private static void KillAll()
        {
            if (threads == null) return;

            for (int i = 0; i < Program.ThreadsCount; i++)
            {
                threads[i].Abort();
            }
            threads = null;
        }

        private static void Caller(object data)
        {
            TaskName task = data as TaskName;
            if (task == null)
            {
                return;
            }
            task.Action(task.ProcessNumber);
        }

        sealed class TaskName
        {
            public Action<int> Action { get; set; }
            public int ProcessNumber { get; set; }

            public TaskName(Action<int> action, int processNumber)
            {
                this.Action = action;
                this.ProcessNumber = processNumber;
            }
        }
    }
}
