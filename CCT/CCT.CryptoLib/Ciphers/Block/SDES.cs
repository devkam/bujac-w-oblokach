using CCT.CryptoLib.Utils;
using System;

namespace CCT.CryptoLib.Ciphers.Block
{
    public class SDES : ICipher
    {
        private readonly int[] IP = { 1, 5, 2, 0, 3, 7, 4, 6 };
        private readonly int[] IIP = { 3, 0, 2, 4, 6, 1, 7, 5 };
        public readonly int[] P10 = { 2, 4, 1, 6, 3, 9, 0, 8, 7, 5 };
        public readonly int[] P8 = { 5, 2, 6, 3, 7, 4, 9, 8 };
        public readonly int[] P4 = { 1, 3, 2, 0 };
        private readonly int[] E = { 3, 0, 1, 2, 1, 2, 3, 0 };

        public SDES() { }

        public void Encrypt(int plaintext, int key)
        {
            int p1 = CombinatoricsUtil.Permutate(plaintext, IP);

            p1 = CombinatoricsUtil.Permutate(p1, IIP);
        }

        public void Decrypt(int ciphertext, int key)
        {
            throw new NotImplementedException();
        }

        private void KeySchedule(int key)
        {

        }

    }
}
