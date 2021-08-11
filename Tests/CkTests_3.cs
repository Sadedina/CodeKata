using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;

namespace Tests
{
    public class CkTests_3
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