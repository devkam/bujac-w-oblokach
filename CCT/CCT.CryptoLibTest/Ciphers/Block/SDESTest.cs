using CCT.CryptoLib.Ciphers.Block;
using NUnit.Framework;

namespace CCT.CryptoLibTest.Ciphers.Block
{
    [TestFixture]
    public class SDESTest
    {
        [Test]
        public void EncryptionTest1()
        {
            SDES sdes = new SDES();
            sdes.Encrypt(165, 151);
        }
    }
}
