using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class CkTests_0_7
    {
        /*  ==================================== Test Case Contents =======================================
         *
         *  1 - Given no ATCG letters the method returns the zero for all the ATCG values
         *  2 - Given ATCG letters in upper case the method return the correct ATCG values
         *  3 - Given ATCG letters in lower case the method return the correct ATCG values
         *  4 - Given ATCG letters in upper and lower case the method return the correct ATCG values
         *  4 - Given random word in upper and lower case the method return the correct ATCG values
         */
        [TestCase("Smuel is very funny", "A:0, T:0, C:0, G:0")]
        [TestCase("12345678910", "A:0, T:0, C:0, G:0")]
        public void WhenGivenAWordWithNoATCG_ATCG_ReturnsZero(string word, string expected)
        {
            Assert.That(CodeKata_0_7.ATCG(word), Is.EqualTo(expected));
        }

        [TestCase("ATCG", "A:1, T:1, C:1, G:1")]
        [TestCase("ATCGGGCTAATAGACT", "A:5, T:4, C:3, G:4")]
        [TestCase("GGCTCTGGTCAGTC", "A:1, T:4, C:4, G:5")]
        [TestCase("AAAAAAAAAA", "A:10, T:0, C:0, G:0")]
        public void WhenGivenAWordWithATCGUpperCase_ATCG_ReturnsCorrectValues(string word, string expected)
        {
            Assert.That(CodeKata_0_7.ATCG(word), Is.EqualTo(expected));
        }

        [TestCase("atcg", "A:1, T:1, C:1, G:1")]
        [TestCase("aagttcgatcga", "A:4, T:3, C:2, G:3")]
        [TestCase("gggtcagtac", "A:2, T:2, C:2, G:4")]
        [TestCase("ccccccccc", "A:0, T:0, C:9, G:0")]
        public void WhenGivenAWordWithATCGLowerCase_ATCG_ReturnsCorrectValues(string word, string expected)
        {
            Assert.That(CodeKata_0_7.ATCG(word), Is.EqualTo(expected));
        }

        [TestCase("aTcG", "A:1, T:1, C:1, G:1")]
        [TestCase("aTCGgatGcAAgCaT", "A:5, T:3, C:3, G:4")]
        [TestCase("gTCGcagAAtaTcA", "A:5, T:3, C:3, G:3")]
        [TestCase("GGGggGggGg", "A:0, T:0, C:0, G:10")]
        public void WhenGivenAWordWithATCGUpperAndLowerCase_ATCG_ReturnsCorrectValues(string word, string expected)
        {
            Assert.That(CodeKata_0_7.ATCG(word), Is.EqualTo(expected));
        }

        [TestCase("pa3T55cfGh", "A:1, T:1, C:1, G:1")]
        [TestCase("QaTHJCG32gbxat10GHcqqAAfgKOCanT", "A:5, T:3, C:3, G:4")]
        [TestCase("rgTklCG12c3aFVBgdAvApopt12aTcA", "A:5, T:3, C:3, G:3")]
        [TestCase("1G12GDDG4gffguGj69ghngHELLOG12g", "A:0, T:0, C:0, G:10")]
        public void WhenGivenARandomWordWithUpperAndLowerCase_ATCG_ReturnsCorrectValues(string word, string expected)
        {
            Assert.That(CodeKata_0_7.ATCG(word), Is.EqualTo(expected));
        }
    }
}