namespace Tests.CodeWars;

[TestFixture]
public class CW11_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("3331148.800", CodeWar11.Height(7));
        Assert.AreEqual("2000000.000", CodeWar11.Height(0));
    }
}