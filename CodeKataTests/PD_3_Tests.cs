namespace PersonalDevelopment.Tests;

public class PD_3_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("bac", PD_3.Switcheroo("abc"));
        Assert.AreEqual("bbbacccabbb", PD_3.Switcheroo("aaabcccbaaa"));
        Assert.AreEqual("ccccc", PD_3.Switcheroo("ccccc"));
    }
}