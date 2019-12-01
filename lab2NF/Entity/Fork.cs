namespace Lab2.Entity
{
    public class Fork
    {
        public int ForkNumber { get; }
        private bool _isFree = true;

        public Fork(int forkNumber)
        {
            ForkNumber = forkNumber;
        }

        public bool isFree()
        {
            return _isFree;
        }

        public bool TakeFork()
        {
            _isFree = false;
            return false;
        }

        public bool ReturnFork()
        {
            _isFree = true;
            return true;
        }
    }
}
