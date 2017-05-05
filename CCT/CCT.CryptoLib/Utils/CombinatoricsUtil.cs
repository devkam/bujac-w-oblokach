using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCT.CryptoLib.Utils
{
    public static class CombinatoricsUtil
    {
        public static int Permutate(int input, int[] permutation)
        {
            int result = 0;
            for (int i = 0; i < permutation.Length; i++)
            {
                result = (result << 1) | (input >> permutation[i] & 1);
            }

            return result;
        }

    }
}
