using System;
using CodeKata.SpartaGlobal;
using NUnit.Framework;

namespace Tests.CodeKata.SpartaGlobal
{
    public class CK_4_Test
    {
        [TestCase("A56")]
        [TestCase("Dinner")]
        [TestCase("123.56")]

        public void GivennNumber_Composed_ReturnsExpectedValue(string num1)
        {
            Assert.That(() => CodeKata_4.Composed(num1), Throws.TypeOf<ArgumentException>()
                .With.Message.Contain("String is not an Integer"));
        }

        [TestCase("A56")]
        [TestCase("Dinner")]
        [TestCase("123.56")]

        public void GivennNumber_Composed2_ReturnsExpectedValue(string num1)
        {
            Assert.That(() => CodeKata_4.Composed_2(num1), Throws.TypeOf<ArgumentException>()
                .With.Message.Contain("String is not an Integer"));
        }

        [TestCase("1", 1)]
        [TestCase("-1", 1)]
        [TestCase("500", 1)]
        [TestCase("-501", -1)]
        [TestCase("1111", 1)]
        [TestCase("72", 1)]

        public void GivennNumber_Composed_ReturnsExpectedValue(string num1, int expectedValue)
        {
            Assert.That(CodeKata_4.Composed(num1), Is.EqualTo(expectedValue));
        }

        [TestCase("1", 1)]
        [TestCase("-1", 1)]
        [TestCase("500", 1)]
        [TestCase("-501", -1)]
        [TestCase("1111", 1)]
        [TestCase("72", 1)]

        public void GivennNumber_Composed2_ReturnsExpectedValue(string num1, int expectedValue)
        {
            Assert.That(CodeKata_4.Composed_2(num1), Is.EqualTo(expectedValue));
        }
    }
}