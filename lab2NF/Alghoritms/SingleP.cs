using Lab2.Entity;

namespace Lab2.Alghoritms
{
    public class SingleP : Alghoritm
    {
        public override string AlgName { get; } = "Single philosopher alghoritm";

        public override bool TryEating(Philosopher philosopher)
        {
            lock(table)
            {
                philosopher.Eat();
            }
            return true;
        }
    }
}
