using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_6_Tests
{
    [TestCase(new int[] { 1, 2, 3 }, 1, 6)]
    public void QueueTime_GivenOneTill_ReturnsCorrectValue(int[] customers, int till, int expected)
    {
        var result = CodeWar_6.QueueTime(customers, till);

        Assert.AreEqual(expected, result);
    }

    [TestCase(new int[] { 1, 2, 4 }, 2, 5)]
    public void QueueTime_GivenTwoTill_ReturnsCorrectValue(int[] customers, int till, int expected)
    {
        var result = CodeWar_6.QueueTime(customers, till);

        Assert.AreEqual(expected, result);
    }

    [TestCase(new int[] { 5, 3, 4 }, 1, 12)]
    [TestCase(new int[] { 2, 3, 10 }, 2, 12)]
    [TestCase(new int[] { 10, 2, 3, 3 }, 2, 10)]
    public void QueueTime_GivenRandomAmountOfTill_ReturnsCorrectValue(int[] customers, int till, int expected)
    {
        var result = CodeWar_6.QueueTime(customers, till);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void ExampleTest1()
    {
        long expected = 0;

        long actual = CodeWar_6.QueueTime(new int[] { }, 1);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ExampleTest2()
    {
        long expected = 10;

        long actual = CodeWar_6.QueueTime(new int[] { 1, 2, 3, 4 }, 1);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ExampleTest3()
    {
        long expected = 9;

        long actual = CodeWar_6.QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ExampleTest4()
    {
        long expected = 5;

        long actual = CodeWar_6.QueueTime(new int[] { 1, 2, 3, 4, 5 }, 100);

        Assert.AreEqual(expected, actual);
    }
}