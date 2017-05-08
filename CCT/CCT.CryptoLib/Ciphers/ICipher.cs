namespace CCT.CryptoLib.Ciphers
{
    public interface ICipher
    {
        int Key { get; set; }

        int Encrypt(int ciphertext);

        int Decrypt(int plaintext);
    }
}
