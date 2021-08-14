using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class CkTests_0_5
    {
        /*  ==================================== Test Case Contents =======================================
         *
         *  1 - The method returns the correct Roman Numeral for integers less than 10
         *  2 - The method returns the correct Roman Numeral for integers between 10 and 100
         *  3 - The method returns the correct Roman Numeral for integers between 100 and 1000
         *  4 - The method returns the correct Roman Numeral for integers between 1000 and 2000
         */

        [TestCase(1, "I")]
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(9, "IX")]
        public void WhenGivenANumberLessThan10_IntoRomanNumerals_ReturnsCorrectString(int num, string expected)
        {
            Assert.That(CodeKata_0_5.IntoRomanNumerals(num), Is.EqualTo(expected));
        }

        [TestCase(10, "X")]
        [TestCase(33, "XXXIII")]
        [TestCase(56, "LVI")]
        [TestCase(72, "LXXII")]
        [TestCase(97, "XCVII")]
        public void WhenGivenANumberBetween10And100_IntoRomanNumerals_ReturnsCorrectString(int num, string expected)
        {
            Assert.That(CodeKata_0_5.IntoRomanNumerals(num), Is.EqualTo(expected));
        }

        [TestCase(100, "C")]
        [TestCase(107, "CVII")]
        [TestCase(169, "CLXIX")]
        [TestCase(201, "CCI")]
        [TestCase(470, "CDLXX")]
        [TestCase(652, "DCLII")]
        [TestCase(836, "DCCCXXXVI")]
        [TestCase(999, "CMXCIX")]
        public void WhenGivenANumberBetween100And1000_IntoRomanNumerals_ReturnsCorrectString(int num, string expected)
        {
            Assert.That(CodeKata_0_5.IntoRomanNumerals(num), Is.EqualTo(expected));
        }

        [TestCase(1000, "M")]
        [TestCase(1007, "MVII")]
        [TestCase(1148, "MCXLVIII")]
        [TestCase(1278, "MCCLXXVIII")]
        [TestCase(1509, "MDIX")]
        [TestCase(1683, "MDCLXXXIII")]
        [TestCase(1825, "MDCCCXXV")]
        public void WhenGivenANumberBetween1000And2000_IntoRomanNumerals_ReturnsCorrectString(int num, string expected)
        {
            Assert.That(CodeKata_0_5.IntoRomanNumerals(num), Is.EqualTo(expected));
        }
    }
}