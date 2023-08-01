using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_2_Tests
{
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
}