using CCT.CryptoLib.Utils;
using NUnit.Framework;

namespace CCT.CryptoLibTest.Utils
{
    [TestFixture]
    public class CombinatoricsUtilTest
    {
        [Test]
        public void CheckSinglePermutate()
        {
            int expectedPermutatedResult = 290;
            int input = 100;
            int[] permutation = { 2, 4, 1, 6, 3, 9, 0, 8, 7, 5 };
            int result = CombinatoricsUtil.Permutate(input, permutation);
            Assert.AreEqual(expectedPermutatedResult, result);
        }

        [Test]
        public void CheckCyclicShiftToLeft()
        {
            int[] inputs = new int[] { 6, 15 };
            int[] expects = new int[] { 12, 30 };
            int numberOfShifts = 1;
            int blockSize = 5;
            for (int i = 0; i < inputs.Length; i++)
            {
                int result = CombinatoricsUtil.CyclicShiftToLeft(inputs[i], numberOfShifts, blockSize);
                Assert.AreEqual(expects[i], result);
            }
        }
    }
}
