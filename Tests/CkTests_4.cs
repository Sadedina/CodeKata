using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;

namespace Tests
{
    public class CkTests_4
    {
        [Test, Description("It should return correct text")]
        public void SampleTest()
        {
            Assert.AreEqual("no one likes this", CodeKata_4.Likes(new string[0]));
            Assert.AreEqual("Peter likes this", CodeKata_4.Likes(new string[] { "Peter" }));
            Assert.AreEqual("Jacob and Alex like this", CodeKata_4.Likes(new string[] { "Jacob", "Alex" }));
            Assert.AreEqual("Max, John and Mark like this", CodeKata_4.Likes(new string[] { "Max", "John", "Mark" }));
            Assert.AreEqual("Alex, Jacob and 2 others like this", CodeKata_4.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
        }
    }
}