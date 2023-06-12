﻿using CodeWars;
using NUnit.Framework;

namespace Tests.CwTests_0;

[TestFixture]
public class CwTests_0_0
{
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

}