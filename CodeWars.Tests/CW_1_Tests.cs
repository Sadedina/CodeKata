namespace Tests.CodeWars;

[TestFixture]
public class CW_1_Tests
{
    #region Find the odd int
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


    #endregion

    #region Mumbling
    private static void testing(string actual, string expected)
    {
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void test1()
    {
        testing(CodeWar_1.Accum("ZpglnRxqenU"), "Z-Pp-Ggg-Llll-Nnnnn-Rrrrrr-Xxxxxxx-Qqqqqqqq-Eeeeeeeee-Nnnnnnnnnn-Uuuuuuuuuuu");
        testing(CodeWar_1.Accum("NyffsGeyylB"), "N-Yy-Fff-Ffff-Sssss-Gggggg-Eeeeeee-Yyyyyyyy-Yyyyyyyyy-Llllllllll-Bbbbbbbbbbb");
        testing(CodeWar_1.Accum("MjtkuBovqrU"), "M-Jj-Ttt-Kkkk-Uuuuu-Bbbbbb-Ooooooo-Vvvvvvvv-Qqqqqqqqq-Rrrrrrrrrr-Uuuuuuuuuuu");
        testing(CodeWar_1.Accum("EvidjUnokmM"), "E-Vv-Iii-Dddd-Jjjjj-Uuuuuu-Nnnnnnn-Oooooooo-Kkkkkkkkk-Mmmmmmmmmm-Mmmmmmmmmmm");
        testing(CodeWar_1.Accum("HbideVbxncC"), "H-Bb-Iii-Dddd-Eeeee-Vvvvvv-Bbbbbbb-Xxxxxxxx-Nnnnnnnnn-Cccccccccc-Ccccccccccc");
    }

    [Test]
    public static void Accum_GivenOneLetter_ReturnsUpperCaseLetter()
    {
        var result = CodeWar_1.Accum("a");
        var expected = "A";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public static void Accum_GivenTwoLetter_ReturnsCorrectLetters()
    {
        var result = CodeWar_1.Accum("ab");
        var expected = "A-Bb";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public static void Accum_GivenThreeLetter_ReturnsCorrectLetters()
    {
        var result = CodeWar_1.Accum("abc");
        var expected = "A-Bb-Ccc";

        Assert.AreEqual(expected, result);
    }
    #endregion
}