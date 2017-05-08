using CCT.CryptoLib.Utils;
using NUnit.Framework;

namespace CCT.CryptoLibTest.Utils
{
    [TestFixture]
    public class CombinatoricsUtilTest
    {
        [Test]
        public void PermutateSingleValue()
        {
            int[] P10 = { 2, 4, 1, 6, 3, 9, 0, 8, 7, 5 };
            int result = CombinatoricsUtil.Permutate(100, P10);
            Assert.AreEqual(290, result);
        }

        [Test]
        public void CyclicShiftToLeft()
        {
            int actual1 = CombinatoricsUtil.CyclicShiftToLeft(6, 1, 5);
            int actual2 = CombinatoricsUtil.CyclicShiftToLeft(15, 1, 5);
            Assert.AreEqual(12, actual1);
            Assert.AreEqual(30, actual2);
        }
    }
}
