using System;

namespace Acomp4
{
    public class RandomArray
    {
        private Random random = new Random();
        public int[] Array;
        public RandomArray(int n)
        {
            Array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Array[i] = random.Next(0, n);
            }
        }
    }
}
