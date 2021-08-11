using NUnit.Framework;
using System;
using CodeKata;

namespace Tests
{
    class CkTests_0
    {
        [Test]
        public void WhenGivenAnEmptyArray_Function_ReturnsException()
        {
            int[] arrs = { };
            Assert.That(() => CodeKata_0.Find(arrs), Throws.TypeOf<Exception>()
                .With.Message.Contains("The list is empty"));
        }

        [TestCase(12)]
        [TestCase(-4)]
        [TestCase(103)]
        public void WhenGivenAnArrayOfSizeOne_Function_ReturnsIntegerInArray(int num)
        {
            int[] arrs = { num };
            Assert.That(() => CodeKata_0.Find(arrs), Throws.TypeOf<Exception>()
                .With.Message.Contains("The list only contains one element"));
        }

        [TestCase(new int[] { 6, 6 })]
        [TestCase(new int[] { 34, 34, 34 })]
        [TestCase(new int[] { -1, -1 })]
        [TestCase(new int[] { -3, -3, -3, -3, -3 })]
        [TestCase(new int[] { 12, 12, 12, 12 })]
        public void WhenGivenAnArrayWithSameNumbers_Function_ReturnsThrowsException(int[] num)
        {
            Assert.That(() => CodeKata_0.Find(num), Throws.TypeOf<Exception>()
                .With.Message.Contains($"All numbers in Array are equal with value {num[0]}."));
        }

        [TestCase(new int[] { 2, 4, 6 }, 4)]
        [TestCase(new int[] { 17, -4, 34, 15, 14 }, 17)]
        [TestCase(new int[] { -2, -4, -6 }, -4)]
        public void WhenGivenAnArray_Function_Returns2HighestIntegerInArray(int[] num, int expectedValue)
        {
            Assert.That(CodeKata_0.Find(num), Is.EqualTo(expectedValue));
        }

        [TestCase(new int[] { 2, 4, 6, 6 }, 4)]
        [TestCase(new int[] { 17, -4, 34, 15, 14, 34 }, 17)]
        [TestCase(new int[] { -2, -4, -6, -2 }, -4)]
        public void WhenGivenAnArrayWith2HighestNumberTheSame_Function_Returns2HighestIntegerInArray(int[] num, int expectedValue)
        {
            Assert.That(CodeKata_0.Find(num), Is.EqualTo(expectedValue));
        }
    }
}
