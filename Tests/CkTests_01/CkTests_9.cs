using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class CkTests_9
    {
        [Test]
        public void ThrowsOutOfRangeException_WhenInputIsNegative()
        {
            Assert.That(() => CodeKata_9.ReturnSumFiboList(-2), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(4, 4)]
        [TestCase(10, 88)]
        [TestCase(15, 986)]
        [TestCase(20, 10945)]
        public void IsAFibonnaciNumber_ReturnsCorrectBool(int value, int expected)
        {
            Assert.That(CodeKata_9.ReturnSumFiboList(value), Is.EqualTo(expected));
        }
    }
}