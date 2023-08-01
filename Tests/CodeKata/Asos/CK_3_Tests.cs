using CodeKata.Asos;
using NUnit.Framework;

namespace Tests.CodeKata.Asos
{
    public class CK_3_Tests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("bac", CodeKata_3.Switcheroo("abc"));
            Assert.AreEqual("bbbacccabbb", CodeKata_3.Switcheroo("aaabcccbaaa"));
            Assert.AreEqual("ccccc", CodeKata_3.Switcheroo("ccccc"));
        }
    }
}