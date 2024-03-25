using NUnit.Framework;
using SoftwareCrafters.SF_Module_4;

namespace Tests.SoftwareCrafters.SF_Module_4;

[TestFixture]
public class ArabicNumbers_Tests
{
    [TestCase("I", 1)]
    [TestCase("II", 2)]
    [TestCase("III", 3)]
    public void Convert_GivenNumberUpToThree_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("IV", 4)]
    [TestCase("V", 5)]
    public void Convert_GivenNumberFourAndFive_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("VI", 6)]
    [TestCase("VII", 7)]
    [TestCase("VIII", 8)]
    public void Convert_GivenNumberSixToEightIncluded_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("IX", 9)]
    [TestCase("X", 10)]
    public void Convert_GivenNumberNineAndTen_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("I", 1)]
    [TestCase("V", 5)]
    [TestCase("X", 10)]
    [TestCase("L", 50)]
    [TestCase("C", 100)]
    [TestCase("D", 500)]
    [TestCase("M", 1000)]
    public void Convert_GivenNumberWithPossibleLetters_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("X", 10)]
    [TestCase("XX", 20)]
    [TestCase("XXX", 30)]
    [TestCase("XL", 40)]
    [TestCase("L", 50)]
    [TestCase("LX", 60)]
    [TestCase("LXX", 70)]
    [TestCase("LXXX", 80)]
    [TestCase("XC", 90)]
    public void Convert_GivenNumberMultipleOfTensToNinety_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("C", 100)]
    [TestCase("CC", 200)]
    [TestCase("CCC", 300)]
    [TestCase("CD", 400)]
    [TestCase("D", 500)]
    [TestCase("DC", 600)]
    [TestCase("DCC", 700)]
    [TestCase("DCCC", 800)]
    [TestCase("CM", 900)]
    public void Convert_GivenNumberMultipleOfHundredsToNineHundred_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase("IV", 4)]
    [TestCase("IX", 9)]
    [TestCase("XXIX", 29)]
    [TestCase("CCXCIV", 294)]
    [TestCase("MMXXIII", 2023)]
    public void Convert_GivenRandomNumbers_ReturnsCorrectNumeral(string romanNumeral, int expectedNumber)
    {
        var result = ArabicNumbers.Convert(romanNumeral);

        Assert.AreEqual(expectedNumber, result);
    }
}