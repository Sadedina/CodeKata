using System.Collections.Generic;
using CodeKata;
using NUnit.Framework;

namespace Tests
{
    public class CkTests_0_1
    {
        [Test]
        public void WhenGiven50_AnswerOfRemainder_Rertuns1()
        {
            var expectedResult = new Dictionary<string, int>();
            expectedResult.Add("£50.00", 1);

            Assert.That(CodeKata_0_1.AnswerOfRemainder(50), Is.EqualTo(expectedResult));
        }

        [Test]
        public void WhenGiven110_AnswerOfRemainder_Rertuns2And1()
        {
            Assert.That(CodeKata_0_1.AnswerOfRemainder(110)["£50.00"], Is.EqualTo(2));
            Assert.That(CodeKata_0_1.AnswerOfRemainder(110)["£10.00"], Is.EqualTo(1));
        }

        [Test]
        public void WhenGiven82n88_AnswerOfRemainder_RertunsDict()
        {
            var expectedDict = new Dictionary<string, int> {
                {"£50.00", 1},
                {"£20.00", 1},
                {"£10.00", 1},
                {"£5.00", 0},
                {"£2.00", 1},
                {"£1.00", 0},
                {"£0.50", 1},
                {"£0.20", 1},
                {"£0.10", 1},
                {"£0.05", 1},
                {"£0.02", 1},
                {"£0.01", 1}
            };

            Assert.That(CodeKata_0_1.AnswerOfRemainder(82.88m), Is.EqualTo(expectedDict));
        }
    }
}