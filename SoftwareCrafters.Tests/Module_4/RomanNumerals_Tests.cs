using SoftwareCrafters.Module_4;

namespace Tests.SoftwareCrafters.Tests.Module_4;

[TestFixture]
public class RomanNumerals_Tests
{
    [TestCase(1, "I")]
    [TestCase(2, "II")]
    [TestCase(3, "III")]
    public void Convert_GivenNumberUpToThree_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(4, "IV")]
    [TestCase(5, "V")]
    public void Convert_GivenNumberFourAndFive_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(6, "VI")]
    [TestCase(7, "VII")]
    [TestCase(8, "VIII")]
    public void Convert_GivenNumberSixToEightIncluded_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(9, "IX")]
    [TestCase(10, "X")]
    public void Convert_GivenNumberNineAndTen_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(1, "I")]
    [TestCase(5, "V")]
    [TestCase(10, "X")]
    [TestCase(50, "L")]
    [TestCase(100, "C")]
    [TestCase(500, "D")]
    [TestCase(1000, "M")]
    public void Convert_GivenNumberWithPossibleLetters_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(10, "X")]
    [TestCase(20, "XX")]
    [TestCase(30, "XXX")]
    [TestCase(40, "XL")]
    [TestCase(50, "L")]
    [TestCase(60, "LX")]
    [TestCase(70, "LXX")]
    [TestCase(80, "LXXX")]
    [TestCase(90, "XC")]
    public void Convert_GivenNumberMultipleOfTensToNinety_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(100, "C")]
    [TestCase(200, "CC")]
    [TestCase(300, "CCC")]
    [TestCase(400, "CD")]
    [TestCase(500, "D")]
    [TestCase(600, "DC")]
    [TestCase(700, "DCC")]
    [TestCase(800, "DCCC")]
    [TestCase(900, "CM")]
    public void Convert_GivenNumberMultipleOfHundredsToNineHundred_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(4, "IV")]
    [TestCase(9, "IX")]
    [TestCase(29, "XXIX")]
    [TestCase(294, "CCXCIV")]
    [TestCase(1900, "MCM")]
    [TestCase(2023, "MMXXIII")]
    public void Convert_GivenRandomNumbers_ReturnsCorrectNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.Convert(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }
}