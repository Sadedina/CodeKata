using CodeKata.Asos;
using NUnit.Framework;

namespace Tests.CodeKata.Asos
{
    public class CK_2_Tests
    {
        [Test]
        public void One()
        {
            Assert.AreEqual(new int[] { 1, 15, 15 }, CodeKata_2.humanYearsCatYearsDogYears(1));
        }

        [Test]
        public void Two()
        {
            Assert.AreEqual(new int[] { 2, 24, 24 }, CodeKata_2.humanYearsCatYearsDogYears(2));
        }

        [Test]
        public void Ten()
        {
            Assert.AreEqual(new int[] { 10, 56, 64 }, CodeKata_2.humanYearsCatYearsDogYears(10));
        }
    }
}