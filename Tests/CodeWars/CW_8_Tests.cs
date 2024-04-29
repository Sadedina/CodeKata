using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_8_Tests
{
    [Test]
    public void exampleTests()
    {
        var bowling = new CodeWar_8();
        int[] testArray = new int[] { 1, 2, 3 };
        Assert.AreEqual("I I I I\n I I I \n       \n       ", bowling.BowlingPins(testArray));

        testArray = new int[] { 3, 5, 9 };
        Assert.AreEqual("I I   I\n I   I \n  I    \n   I   ", bowling.BowlingPins(testArray));
    }
}