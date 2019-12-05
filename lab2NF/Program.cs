using Lab2.Alghoritms;
using Lab2.Entity;
using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        public const int ThreadsCount = 5;
        public const int TimeForWaiting = 0;
        public const int TimeForEating = 0;
        public const int MaxWorkingTime = 2000;

        private static List<Alghoritm> alghoritms = 
            new List<Alghoritm>() {
                new Own(),
                new Hierarchy(),
                new SmartTable(),
                new SingleP(),
                new Timelock(),
                new Livelock(),
                new Deadlock()
            };

        static void Main(string[] args)
        {
            foreach (var alghoritm in alghoritms)
            {
                Console.WriteLine(alghoritm.Execute(new Table()));
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
