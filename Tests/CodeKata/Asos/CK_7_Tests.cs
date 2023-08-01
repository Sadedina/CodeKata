using CodeKata.Asos;
using NUnit.Framework;

namespace Tests.CodeKata.Asos
{
    public class CK_7_Tests
    {
        /*  ==================================== Test Case Contents =======================================
         *
         *  1 - Duplicates returns correct array of duplicated characters
         *  2 - Duplicate returns empty if there's no duplicates
         */


        [Test]
        public void CheckDuplicates_Returns_CorrectArrayOfCharacters()
        {
            string input = "Nishant Mandal".ToLower();
            char[] expected = new char[] { 'n', 'a' };
            Assert.That(CodeKata_7.Duplicates(input), Is.EqualTo(expected));
        }


        [Test]
        public void Duplicates_ReturnsEmptyArr_IfNoDuplicatesWereFound()
        {
            string input = "Samuel".ToLower();
            Assert.That(CodeKata_7.Duplicates(input), Is.Empty);
        }

    }
}