using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_3_Tests
{
    #region Price of Mangoes
    [Test]
    public void Mango_GivenOneMango_ReturnsThree()
        => Assert.AreEqual(3, CodeWar_3.Mango(1, 3));

    [Test]
    public void Mango_GivenTwoMangoes_ReturnsSix()
        => Assert.AreEqual(6, CodeWar_3.Mango(2, 3));

    [Test]
    public void Mango_GivenThreeMangoes_ReturnsSix()
        => Assert.AreEqual(6, CodeWar_3.Mango(3, 3));

    [Test]
    public void Mango_GivenFourMangoes_ReturnsSix()
        => Assert.AreEqual(9, CodeWar_3.Mango(4, 3));

    [Test]
    public void Mango_GivenFiveMangoes_ReturnsTwelve()
        => Assert.AreEqual(12, CodeWar_3.Mango(5, 3));

    [Test]
    public void Mango_GivenSixMangoes_ReturnsTwelve()
        => Assert.AreEqual(12, CodeWar_3.Mango(6, 3));

    [Test]
    public void Mango_GivenSevenMangoes_ReturnsFifteen()
        => Assert.AreEqual(15, CodeWar_3.Mango(7, 3));

    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(6, CodeWar_3.Mango(3, 3));
        Assert.AreEqual(30, CodeWar_3.Mango(9, 5));
    }
    #endregion

    #region Sum a list but ignore any duplicates
    [TestCase(new int[] { 1 }, 1)]
    [TestCase(new int[] { 1, 2, 3 }, 6)]
    [TestCase(new int[] { 1, 2, 3, 4 }, 10)]
    public void SumNoDuplicates_GivenAnArrayWithNoDuplicates_ReturnsSumOfArray(int[] arr, int expectedSum)
        => Assert.AreEqual(expectedSum, CodeWar_3.SumNoDuplicates(arr));

    [TestCase(new int[] { 1, 1 }, 0)]
    [TestCase(new int[] { 1, 2, 3, 1 }, 5)]
    [TestCase(new int[] { 1, 2, 3, 4, 2 }, 8)]
    public void SumNoDuplicates_GivenAnArrayWithDuplicates_ReturnsSumOfArray(int[] arr, int expectedSum)
        => Assert.AreEqual(expectedSum, CodeWar_3.SumNoDuplicates(arr));

    [TestCase(new int[] { 1, 1, 1 }, 0)]
    [TestCase(new int[] { 1, 2, 3, 1, 1 }, 5)]
    [TestCase(new int[] { 1, 2, 3, 4, 2, 2 }, 8)]
    public void SumNoDuplicates_GivenAnArrayWithTriples_ReturnsSumOfArray(int[] arr, int expectedSum)
        => Assert.AreEqual(expectedSum, CodeWar_3.SumNoDuplicates(arr));

    [Test]
    public void MyTest()
    {
        Assert.AreEqual(5, CodeWar_3.SumNoDuplicates(new int[] { 1, 1, 2, 3 }));
        Assert.AreEqual(3, CodeWar_3.SumNoDuplicates(new int[] { 1, 1, 2, 2, 3 }));
    }
    #endregion
}