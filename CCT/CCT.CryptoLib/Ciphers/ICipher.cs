using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCT.CryptoLib.Ciphers
{
    public interface ICipher
    {
        void Encrypt(int ciphertext, int key);

        void Decrypt(int plaintext, int key);
    }
}
