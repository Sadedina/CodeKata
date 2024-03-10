﻿using NUnit.Framework;
using SoftwareCrafters;

namespace Tests.SoftwareCrafters;

[TestFixture]
public class SF_Module1Tests
{
    [TestCase(2004)]
    [TestCase(2008)]
    [TestCase(2012)]
    [TestCase(2016)]
    public void LeapYearCalculator_GivenAYearDivisibleByFour_ReturnsTrue(int year)
    {
        var result = SF_Module1.LeapYearCalculator(year);

        Assert.IsTrue(result);
    }

    [TestCase(1900)]
    [TestCase(2100)]
    [TestCase(2200)]
    [TestCase(2300)]
    public void LeapYearCalculator_GivenAYearIsDivisibleByOneHundred_ReturnsFalse(int year)
    {
        var result = SF_Module1.LeapYearCalculator(year);

        Assert.IsFalse(result);
    }

    [TestCase(2400)]
    [TestCase(2000)]
    [TestCase(1600)]
    [TestCase(1200)]
    public void LeapYearCalculator_GivenAYearIsDivisibleByFourHundred_ReturnsTrue(int year)
    {
        var result = SF_Module1.LeapYearCalculator(year);

        Assert.IsTrue(result);
    }

    [TestCase(1996, true)]
    [TestCase(2001, false)]
    [TestCase(2000, true)]
    [TestCase(1900, false)]
    public void LeapYearCalculator_GivenATest_ReturnsCorrectValues(int year, bool isALeapYear)
    {
        var result = SF_Module1.LeapYearCalculator(year);

        Assert.AreEqual(isALeapYear, result);
    }


}