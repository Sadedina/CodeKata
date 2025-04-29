namespace Tests.CodeWars;

[TestFixture]
public class CW12_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("990534330", CodeWar12.Biggest(new[] { 9, 3, 34, 5, 90, 30 }));
    }

    [TestCase(new[] { 5, 1, 7 }, "751")]
    [TestCase(new[] { 4, 8, 3 }, "843")]
    [TestCase(new[] { 5, 6, 8 }, "865")]
    public void Biggest_GivenAnArrayOfSingleDigit_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 1, 5, 1, 7 }, "7511")]
    [TestCase(new[] { 7, 5, 3, 7 }, "7753")]
    [TestCase(new[] { 7, 7, 9, 7 }, "9777")]
    public void Biggest_GivenAnArrayWithDuplicateSingleDigit_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 13, 53, 17, 78 }, "78531713")]
    [TestCase(new[] { 75, 52, 37, 77 }, "77755237")]
    [TestCase(new[] { 77, 74, 90, 73 }, "90777473")]
    public void Biggest_GivenAnArrayWithDoubleDigit_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 77, 77, 77 }, "777777")]
    [TestCase(new[] { 77, 97, 77 }, "977777")]
    public void Biggest_GivenAnArrayWithSameDoubleDigit_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 7, 54 }, "754")]
    [TestCase(new[] { 54, 7 }, "754")]
    [TestCase(new[] { 92, 9294 }, "929492")]
    [TestCase(new[] { 92, 9291 }, "929291")]
    [TestCase(new[] { 92, 929 }, "92992")]
    [TestCase(new[] { 5455, 545554 }, "5455545554")]
    [TestCase(new[] { 5455, 545555 }, "5455555455")]
    public void Biggest_GivenAnArrayWithDifferentDigitSize_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 553, 53, 5 }, "555353")]
    [TestCase(new[] { 565, 57, 5, 54, 501 }, "57565554501")]
    [TestCase(new[] { 9, 30, 5, 90, 3, 34, 91 }, "99190534330")]
    public void Biggest_GivenARandomArray_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }

    [TestCase(new[] { 0, 0, 0 }, "0")]
    [TestCase(new[] { 0, 1, 0, 0, 0 }, "10000")]
    public void Biggest_GivenARandomEdgeCases_ReturnsCorrectBiggestNumber(int[] array, string result)
    {
        var sut = CodeWar12.Biggest(array);

        Assert.AreEqual(result, sut);
    }
}