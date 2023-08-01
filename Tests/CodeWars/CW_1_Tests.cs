using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_1_Tests
{
    [Test]
    public void Tests()
    {
        Assert.AreEqual(5, CodeWar_1.find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
    }

    [Test]
    public void find_it_GivenAnArrayWithPositiveIntegers_ReturnsTheRepeatedOddTimeNumber()
    {
        var sequence = new[] { 1, 1, 2, 2, 3, 3, 5, 5, 5 };

        var solution = CodeWar_1.find_it(sequence);

        Assert.AreEqual(5, solution);
    }

    [Test]
    public void find_it_GivenAnArrayWithNegativeIntegers_ReturnsTheRepeatedOddTimeNumber()
    {
        var sequence = new[] { -1, -1, -2, -2, -3, -3, -5, -5, -5 };

        var solution = CodeWar_1.find_it(sequence);

        Assert.AreEqual(-5, solution);
    }

}