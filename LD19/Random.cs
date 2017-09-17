using System;

namespace LD19
{
    public static class Random
    {
        private static System.Random random = new System.Random( DateTime.Now.Millisecond);

        public static int Next( int lowest, int highest )
        {
            return random.Next( lowest, highest + 1 );
        }
    }
}
