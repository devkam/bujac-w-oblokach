using CCT.CryptoLib.Ciphers.Block;
using NUnit.Framework;

namespace CCT.CryptoLibTest.Ciphers.Block
{
    [TestFixture]
    public class SDESTest
    {
        int key = 798;
        int plainText = 40;
        int cipherText;
        SDES sdes;

        [SetUp]
        public void Init()
        {
            sdes = new SDES(key);
            cipherText = sdes.Encrypt(plainText);
        }


        [Test]
        public void CheckIfDecryptedCipherTextCanBeRead()
        {
            int result = sdes.Decrypt(cipherText);
            Assert.AreEqual(cipherText, 138);
            Assert.AreEqual(plainText, result);
        }

        [Test]
        public void CheckIfSubkeysAreValid()
        {
            Assert.AreEqual(sdes.Subkeys[0], 233);
            Assert.AreEqual(sdes.Subkeys[1], 167);
        }
    }
}
