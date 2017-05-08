using CCT.CryptoLib.Utils;

namespace CCT.CryptoLib.Ciphers.Block
{
    public class SDES : ICipher
    {
        const int HALF_OF_BLOCK = 4;
        const int HALF_OF_KEY = 5;

        private readonly int[] IP = { 1, 5, 2, 0, 3, 7, 4, 6 };
        private readonly int[] IIP = { 3, 0, 2, 4, 6, 1, 7, 5 };
        public readonly int[] P10 = { 2, 4, 1, 6, 3, 9, 0, 8, 7, 5 };
        public readonly int[] P8 = { 5, 2, 6, 3, 7, 4, 9, 8 };
        public readonly int[] P4 = { 1, 3, 2, 0 };
        private readonly int[] E = { 3, 0, 1, 2, 1, 2, 3, 0 };

        private readonly int[][] S_BOXES = {
            new int[]{
                1, 0, 3, 2,
                3, 2, 1, 0,
                0, 2, 1, 3,
                3, 1, 3, 2
            },
            new int[]{
                0, 1, 2, 3,
                2, 0, 1, 3,
                3, 0, 1, 0,
                2, 1, 0, 3
            }
        };

        private int[] subkeys;
        public int[] Subkeys { get { return subkeys; } }

        private int key;
        public int Key
        {
            set
            {
                key = value;
                KeySchedule(key);
            }
            get { return key; }
        }

        public SDES(int key)
        {
            Key = key;
        }

        public int Encrypt(int plaintext)
        {
            return Transform(plaintext, 0, 1);
        }

        public int Decrypt(int ciphertext)
        {
            return Transform(ciphertext, 1, 0);
        }

        private int Transform(int data, int firstSubkeyIdx, int secondSubkeyIdx)
        {
            int block = CombinatoricsUtil.Permutate(data, IP);
            block = fK(block, subkeys[firstSubkeyIdx]);
            block = SW(block);
            block = fK(block, subkeys[secondSubkeyIdx]);
            return CombinatoricsUtil.Permutate(block, IIP);
        }

        private int[] KeySchedule(int key)
        {
            int permutatedKey = CombinatoricsUtil.Permutate(key, P10);
            int[] parts = CombinatoricsUtil.Halve(permutatedKey, HALF_OF_KEY);
            int left = parts[0];
            int right = parts[1];
            subkeys = new int[2];

            for (int i = 0; i < 2; i++)
            {
                left = CombinatoricsUtil.CyclicShiftToLeft(left, i + 1, HALF_OF_KEY);
                right = CombinatoricsUtil.CyclicShiftToLeft(right, i + 1, HALF_OF_KEY);
                subkeys[i] = CombinatoricsUtil.Permutate((left << HALF_OF_KEY) | right, P8);
            }

            return subkeys;
        }

        private int fK(int block, int subkey)
        {
            var parts = CombinatoricsUtil.Halve(block, HALF_OF_BLOCK);
            return ((parts[0] ^ F(parts[1], subkey)) << HALF_OF_BLOCK | parts[1]);
        }

        private int F(int block, int subkey)
        {
            int extended = CombinatoricsUtil.Permutate(block, E) ^ subkey;
            var parts = CombinatoricsUtil.Halve(extended, HALF_OF_BLOCK);
            int left = S_BOXES[0][FindSBoxIndex(parts[0])];
            int right = S_BOXES[1][FindSBoxIndex(parts[1])];
            return CombinatoricsUtil.Permutate((left << 2) | right, P4);
        }

        private int FindSBoxIndex(int block)
        {
            int row = ((block & 0x8) >> 2) | (block & 1);
            int column = (block >> 1) & 0x3;
            return row * 4 + column;
        }

        private int SW(int x)
        {
            return CombinatoricsUtil.CyclicShiftToLeft(x, 4, 8);
        }
    }
}
