using System;
using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_2_Tests
{
    #region What century is it?
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("20th", CodeWar_2.WhatCentury("1999"), "With input '1999' solution produced wrong output.");
        Assert.AreEqual("21st", CodeWar_2.WhatCentury("2011"), "With input '2011' solution produced wrong output.");
        Assert.AreEqual("22nd", CodeWar_2.WhatCentury("2154"), "With input '2154' solution produced wrong output.");
        Assert.AreEqual("23rd", CodeWar_2.WhatCentury("2259"), "With input '2259' solution produced wrong output.");
    }

    [Test]
    public void WhatCentury_Returns20thCentury()
    {
        Assert.AreEqual("20th", CodeWar_2.WhatCentury("1901"), "With input '1901' solution produced wrong output.");
        Assert.AreEqual("20th", CodeWar_2.WhatCentury("2000"), "With input '2000' solution produced wrong output.");
    }

    [Test]
    public void WhatCentury_Returns21stCentury()
    {
        Assert.AreEqual("21st", CodeWar_2.WhatCentury("2001"), "With input '2001' solution produced wrong output.");
        Assert.AreEqual("21st", CodeWar_2.WhatCentury("2100"), "With input '2100' solution produced wrong output.");
    }

    [Test]
    public void WhatCentury_Returns22ndCentury()
    {
        Assert.AreEqual("22nd", CodeWar_2.WhatCentury("2101"), "With input '2001' solution produced wrong output.");
        Assert.AreEqual("22nd", CodeWar_2.WhatCentury("2200"), "With input '2100' solution produced wrong output.");
    }
    #endregion

    #region MyRegion
    private void DoTest(int seconds, String expected)
    {
        String actual = CodeWar_2.GetReadableTime(seconds);
        Assert.AreEqual(expected, actual, "for " + seconds + " seconds");
    }

    [Test]
    public void SampleTests()
    {
        DoTest(0, "00:00:00");
        DoTest(59, "00:00:59");
        DoTest(60, "00:01:00");
        DoTest(90, "00:01:30");
        DoTest(3599, "00:59:59");
        DoTest(3600, "01:00:00");
        DoTest(45296, "12:34:56");
        DoTest(86399, "23:59:59");
        DoTest(86400, "24:00:00");
        DoTest(359999, "99:59:59");
    }

    [Test]
    public static void GetReadableTime_Given1second_ReturnsCorrectTime()
    {
        var result = CodeWar_2.GetReadableTime(1);
        var expected = "00:00:01";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public static void GetReadableTime_Given30seconds_ReturnsCorrectTime()
    {
        var result = CodeWar_2.GetReadableTime(30);
        var expected = "00:00:30";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public static void GetReadableTime_Given1minute_ReturnsCorrectTime()
    {
        var result = CodeWar_2.GetReadableTime(60);
        var expected = "00:01:00";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public static void GetReadableTime_Given30minutes1second_ReturnsCorrectTime()
    {
        var result = CodeWar_2.GetReadableTime(1801);
        var expected = "00:30:01";

        Assert.AreEqual(expected, result);
    }
    #endregion

}