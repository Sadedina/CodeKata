using NUnit.Framework;
using SoftwareCrafters.SF_Module_4;

namespace Tests.SoftwareCrafters.SF_Module_4;

[TestFixture]
public class RomanNumerals_Tests
{
    [TestCase(1, "I")]
    [TestCase(2, "II")]
    [TestCase(3, "III")]
    public void ConvertIntoRomanNumerals_GivenNumbersUpToThree_ReturnsCorrectRomanNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.ConvertIntoRomanNumerals(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(4, "IV")]
    [TestCase(5, "V")]
    public void ConvertIntoRomanNumerals_GivenNumbersFourAndFive_ReturnsCorrectRomanNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.ConvertIntoRomanNumerals(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(6, "VI")]
    [TestCase(7, "VII")]
    [TestCase(8, "VIII")]
    public void ConvertIntoRomanNumerals_GivenNumbersSixToEightIncluded_ReturnsCorrectRomanNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.ConvertIntoRomanNumerals(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

    [TestCase(9, "IX")]
    [TestCase(10, "X")]
    public void ConvertIntoRomanNumerals_GivenNumbersNineAndTen_ReturnsCorrectRomanNumeral(int arabicNumber, string expectedNumber)
    {
        var result = RomanNumerals.ConvertIntoRomanNumerals(arabicNumber);

        Assert.AreEqual(expectedNumber, result);
    }

}