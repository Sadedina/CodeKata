namespace Tests.CodeWars;

[TestFixture]
public class CW_7_Tests
{
    #region Cat years, Dog years
    [Test]
    public void One()
    {
        Assert.AreEqual(new int[] { 1, 15, 15 }, CodeWar_7.HumanYearsCatYearsDogYears(1));
    }

    [Test]
    public void Two()
    {
        Assert.AreEqual(new int[] { 2, 24, 24 }, CodeWar_7.HumanYearsCatYearsDogYears(2));
    }

    [Test]
    public void Ten()
    {
        Assert.AreEqual(new int[] { 10, 56, 64 }, CodeWar_7.HumanYearsCatYearsDogYears(10));
    }
    #endregion

    #region Cat years, Dog years (2)
    [Test]
    public void OwnedCatAndDog_One()
    {
        Assert.AreEqual((1, 1), CodeWar_7.OwnedCatAndDog(15, 15));
    }

    [Test]
    public void OwnedCatAndDog_Two()
    {
        Assert.AreEqual((2, 2), CodeWar_7.OwnedCatAndDog(24, 24));
    }

    [Test]
    public void OwnedCatAndDog_Ten()
    {
        Assert.AreEqual((10, 10), CodeWar_7.OwnedCatAndDog(56, 64));
    }
    #endregion
}