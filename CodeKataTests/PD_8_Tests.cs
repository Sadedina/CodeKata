namespace PersonalDevelopment.Tests;

public class PD_8_Tests
{
    /*  ==================================== Test Case Contents =======================================
     *
     *  1 - FibonacciSequence correctly adds the value to a Dicitonary and identifies when a number is in the Fibonacci sequence
     *  2 - FibonacciSequence correctly adds the value to a Dicitonary and identifies when a number is NOT in the Fibonacci sequence
     *  3 - IsInTheAFibonacciSequence returns correct boolean when identifying a Fibonacci
     *  3 - IsAFibonnaciNumber returns correct boolean when identifying a Fibonacci
     */
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(196_418)]
    [TestCase(317_811)]
    public void FibonacciSequence_CorrectlyIdentifies_NumbersBelongingToFibonacciSeq(int value)
    {
        var inputArr = new int[] { 0, 1, 4, 10, 20_000, 196_418, 317_811 };
        Assert.True(PD_8.FibonacciSequence(inputArr)[value]);
    }

    [TestCase(4)]
    [TestCase(10)]
    [TestCase(20_000)]
    public void FibonacciSequence_CorrectlyIdentifies_NumbersNotBelongingToFibonacciSeq(int value)
    {
        var inputArr = new int[] { 0, 1, 4, 10, 19_6418, 20_000, 31_7811 };
        Assert.False(PD_8.FibonacciSequence(inputArr)[value]);
    }

    [TestCase(-1, false)]
    [TestCase(0, true)]
    [TestCase(21, true)]
    [TestCase(86, false)]
    [TestCase(20_000, false)]
    [TestCase(196418, true)]
    public void IsInTheFibonacciSequence_ReturnsCorrectBool(int value, bool expected)
    {
        Assert.That(PD_8.IsInTheFibonacciSequence(value), Is.EqualTo(expected));
    }

    [TestCase(-100, false)]
    [TestCase(-1, false)]
    [TestCase(0, true)]
    [TestCase(1, true)]
    [TestCase(3, true)]
    [TestCase(5, true)]
    [TestCase(9, false)]
    [TestCase(21, true)]
    [TestCase(86, false)]
    [TestCase(20_000, false)]
    [TestCase(196418, true)]
    public void IsAFibonnaciNumber_ReturnsCorrectBool(int value, bool expected)
        => Assert.That(PD_8.IsAFibonnaciNumber(value), Is.EqualTo(expected));
}