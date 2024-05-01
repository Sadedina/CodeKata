namespace Tests.CodeWars;

[TestFixture]
public class CW_4_Tests
{
    #region Is he gonna survive?
    [Test]
    public void Hero_GivenZeroBullets_AndNoDragons_ReturnsTrue()
    {
        Assert.IsTrue(CodeWar_4.Hero(0, 0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Hero_GivenLessThanTwoBullets_AndADragon_ReturnsFalse(int bullets)
    {
        Assert.IsFalse(CodeWar_4.Hero(bullets, 1));
    }

    [TestCase(1)]
    [TestCase(3)]
    public void Hero_GivenLessThanFourBullets_AndTwoDragons_ReturnsFalse(int bullets)
    {
        Assert.IsFalse(CodeWar_4.Hero(bullets, 2));
    }

    [TestCase(10, 5)]
    [TestCase(100, 40)]
    public void ATrueHero(int bullets, int dragons)
    {
        Assert.IsTrue(CodeWar_4.Hero(bullets, dragons));
    }

    [TestCase(4, 5)]
    [TestCase(1500, 751)]
    [TestCase(0, 1)]
    [TestCase(7, 4)]
    public void AFalseHero(int bullets, int dragons)
    {
        Assert.IsFalse(CodeWar_4.Hero(bullets, dragons));
    }
    #endregion

    #region Death by Coffee
    //[TestCase("2", 2)]
    //[TestCase("A", 10)]
    //[TestCase("F", 15)]
    //public void FormatFromHexadecimal_GivenHexadecimal_ReturnsCorrectInteger(string hexaValue, int expectedValue)
    //{
    //    var result = CodeWar_4.FormatFromHexadecimal(hexaValue);

    //    Assert.AreEqual(expectedValue, result);
    //}

    //[TestCase(01, "01")]
    //[TestCase(3, "03")]
    //[TestCase(11, "11")]
    //public void AddPrefixToDate_GivenDate_ReturnsCorrectValue(int date, string expectedValue)
    //{
    //    var result = CodeWar_4.AddPrefixToDate(date);

    //    Assert.AreEqual(expectedValue, result);
    //}

    //[TestCase(01, "1")]
    //[TestCase(3, "3")]
    //[TestCase(10, "A")]
    //[TestCase(15, "F")]
    //public void FormatDateOfBirth_GivenBirthday_ReturnsCorrectValue(int interger, string hexaValue)
    //{
    //    var result = CodeWar_4.FormatIntoHexadecimal(interger);

    //    Assert.AreEqual(hexaValue, result);
    //}

    //[TestCase(01, "1")]
    //[TestCase(3, "3")]
    //[TestCase(10, "A")]
    //[TestCase(15, "F")]
    //public void FormatDateOfBirth_GivenBirthday_ReturnsCorrectValue(int interger, string hexaValue)
    //{
    //    var result = CodeWar_4.FormatIntoHexadecimal(interger);

    //    Assert.AreEqual(hexaValue, result);
    //}

    //[TestCase("DEAD", true)]
    //[TestCase("12SDEAD", true)]
    //[TestCase("1a3DEAD234", true)]
    //[TestCase("DE2AD", false)]
    //[TestCase("12SDEA", false)]
    //[TestCase("1a3EAD234", false)]

    //public void FormatDateOfBirth_GivenBirthday_ReturnsCorrectValue(string hexaValue, bool expectedBool)
    //{
    //    var result = CodeWar_4.DeathEvaluator(hexaValue);

    //    Assert.AreEqual(expectedBool, result);
    //}

    // Show returned limits
    private static (int, int) Show(int y, int m, int d, (int, int) result)
    {
        Console.WriteLine($"{y:D4}{m:D2}{d:D2} => {result}");
        return result;
    }

    [Test]
    public void ExJohn()
    {
        int y = 1950, m = 1, d = 19;
        Assert.AreEqual((2645, 1162), Show(y, m, d, CodeWar_4.CoffeeLimits(y, m, d)));
    }

    [Test]
    public void ExSusan()
    {
        int y = 1965, m = 12, d = 11;
        Assert.AreEqual((111, 0), Show(y, m, d, CodeWar_4.CoffeeLimits(y, m, d)));
    }

    [Test]
    public void ExElizabeth()
    {
        int y = 1964, m = 11, d = 28;
        Assert.AreEqual((0, 11), Show(y, m, d, CodeWar_4.CoffeeLimits(y, m, d)));
    }

    [Test]
    public void ExPeter()
    {
        int y = 1965, m = 9, d = 4;
        Assert.AreEqual((0, 0), Show(y, m, d, CodeWar_4.CoffeeLimits(y, m, d)));
    }
    #endregion
}