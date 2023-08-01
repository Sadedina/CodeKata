using CodeKata.SpartaGlobal;
using NUnit.Framework;

namespace Tests.CodeKata.SpartaGlobal
{
    public class CK_3_Test
    {
        [TestCase(1, 2, 90)]
        [TestCase(14, 16, 200)]
        [TestCase(4, 10, 345)]
        [TestCase(0, 5, 258)]
        [TestCase(13, 15, 198)]
        [TestCase(8, 8, 24)]

        public void Givenn1Andn2_SumArrayInt_ReturnsExpectedValue(int num1, int num2, int expectedValue)
        {
            //                  0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16 
            int[] anArray = { 03, 56, 34, 97, 52, 16, 43, 71, 24, 85, 54, 44, 2, 11, 99, 88, 13 };
            Assert.That(CodeKata_3.SumArrayInt(num1, num2, anArray), Is.EqualTo(expectedValue));
        }
    }
}