using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;
using System;

namespace Tests
{
    public class CkTests_0_8
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
    }
}