using System;
using CodeKata.Asos;
using NUnit.Framework;

namespace Tests.CodeKata.Asos
{
    public class CK_5_Tests
    {
        [TestCase(new int[] { -1, -7, -11 }, new int[] { -1, 0 })]
        [TestCase(new int[] { 7, 24, 3 }, new int[] { 3, 0 })]
        [TestCase(new int[] { 3, 3, 5, 7 }, new int[] { 3, 0 })]
        [TestCase(new int[] { -11, 5, -3, 7, 3 }, new int[] { -3, 3 })]
        public void GivenArraysToFindClosestToZero_Return_CorrectSetOfInts(int[] input, int[] expected)
        {
            Assert.AreEqual(expected, CodeKata_5.ClosestToZero(input));
        }

        [Test]
        public void GivenEmptyArrayTofindClosestToZero_Throws_ArgumentNullException()
        {
            Assert.That(() => CodeKata_5.ClosestToZero(new int[] { }), Throws.TypeOf<ArgumentNullException>().With.Message.Contains("List is empty"));
        }
    }
}