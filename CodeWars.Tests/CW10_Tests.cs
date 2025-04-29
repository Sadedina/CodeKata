namespace Tests.CodeWars;

[TestFixture]
public class CW10_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.That(CodeWar10.GrowingPlant(100, 10, 910), Is.EqualTo(10));
        Assert.That(CodeWar10.GrowingPlant(10, 9, 4), Is.EqualTo(1));
    }
}