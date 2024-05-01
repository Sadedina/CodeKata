namespace PersonalDevelopment.Tests;

public class PD_1_Tests
{
    [TestCase(7, new long[] { 7 })]
    [TestCase(31, new long[] { 1, 3 })]
    [TestCase(348597, new long[] { 7, 9, 5, 8, 4, 3 })]
    public void MyTest(long num, long[] expectedResult)
        => Assert.AreEqual(expectedResult, PD_1.Digitize(num));
}