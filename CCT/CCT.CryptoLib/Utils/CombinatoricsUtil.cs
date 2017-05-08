using System;
using System.Linq;

namespace CCT.CryptoLib.Utils
{
    public static class CombinatoricsUtil
    {
        public static int Permutate(int input, int[] permutation)
        {
            int result = 0;
            for (int i = 0; i < permutation.Length; i++)
            {
                result <<= 1;
                result |= (input >> (permutation.Max() - permutation[i]) & 1);
            }

            return result;
        }

        public static int[] Halve(int value, int position)
        {
            int size = (int)Math.Pow(2, position) - 1;
            return new int[] { (value >> position) & size, value & size };
        }

        public static int CyclicShiftToLeft(int value, int times, int length)
        {
            int msb = (int)Math.Pow(2, length - 1);
            int rest = (int)Math.Pow(2, length) - 1;
            for (int i = 0; i < times; i++)
            {
                value = ((value & rest) << 1) | ((value & msb) >> (length - 1));
            }

            return value;
        }
    }
}
