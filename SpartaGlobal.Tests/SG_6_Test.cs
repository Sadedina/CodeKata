namespace SpartaGlobal.Tests;

public class SG_6_Test
{
    [TestCase(1, "1")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(15, "Fizz Buzz")]
    [TestCase(22, "22")]
    [TestCase(27, "Fizz")]
    [TestCase(50, "Buzz")]
    [TestCase(60, "Fizz Buzz")]
    [TestCase(64, "64")]
    public void WhenGivenANumber_FizzBuzz_ReturnsCorrectString(int num, string expected)
    {
        Assert.That(SG_6.FizzBuzz(num), Is.EqualTo(expected));
    }

}