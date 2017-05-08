using CCT.CryptoLib.Ciphers.Block;
using NUnit.Framework;

namespace CCT.CryptoLibTest.Ciphers.Block
{
    [TestFixture]
    public class SDESTest
    {
        int key = 798;
        int expectedPlaintext = 40;
        int ciphertext;
        SDES sdes;

        [SetUp]
        public void Init()
        {
            sdes = new SDES(key);
            ciphertext = sdes.Encrypt(expectedPlaintext);
        }

        [Test]
        public void CheckIfDecryptedCipherTextCanBeRead()
        {
            int expectedCiphertext = 138;
            int plaintext = sdes.Decrypt(ciphertext);
            Assert.AreEqual(expectedCiphertext, ciphertext);
            Assert.AreEqual(expectedPlaintext, plaintext);
        }

        [Test]
        public void CheckIfSubkeysAreValid()
        {
            int expectedSubkey1 = 233;
            int expectedSubkey2 = 167;
            Assert.AreEqual(expectedSubkey1, sdes.Subkeys[0]);
            Assert.AreEqual(expectedSubkey2, sdes.Subkeys[1]);
        }
    }
}
