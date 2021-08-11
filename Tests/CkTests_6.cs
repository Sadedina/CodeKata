using NUnit.Framework;
using CodeKata;
using System.Collections.Generic;

namespace Tests
{
    public class CkTests_6
    {
        /*  ==================================== Test Case Contents =======================================
         *
         * 1 - Checks PrimeNumberConversion returns correct Sum of Primes
         * 2 - Checks PrimeNumberConversion returns correct Sum of NONE Primes
         * 3 - Checks PrimeNumberConversion correctly returns NONE Primes as a string
         * 4 - Checks PrimeNumberConversion correctly returns NONE Primes as a Dictionary
         * 5 - Checks CheckIfNumberIsPrimeNumber correctly returns True or False when identifying a prime
         */


        [TestCase]
        public void PrimeNumberConversion_ReturnsCorrect_SumOfPrimes()
        {
            //Arrange
            string output = "";
            string input1 = "Nishant Mandal";
            string input2 = "015";
            string input3 = "";
            int exp1 = 291;
            int exp2 = 53;
            int exp3 = 0;

            //Assert
            Assert.That(CodeKata_6.PrimeNumberConversion(input1, out output).Item1, Is.EqualTo(exp1));
            Assert.That(CodeKata_6.PrimeNumberConversion(input2, out output).Item1, Is.EqualTo(exp2));
            Assert.That(CodeKata_6.PrimeNumberConversion(input3, out output).Item1, Is.EqualTo(exp3));
        }

        [TestCase]
        public void RPrimeNumberConversion_ReturnsCorrect_SumOfNonePrimes()
        {
            //Arrange
            string output = "";
            string input1 = "Nishant Mandal";
            string input2 = "015";
            string input3 = "";
            int exp1 = 1055;
            int exp2 = 97;
            int exp3 = 0;

            //Assert
            Assert.That(CodeKata_6.PrimeNumberConversion(input1, out output).Item3, Is.EqualTo(exp1));
            Assert.That(CodeKata_6.PrimeNumberConversion(input2, out output).Item3, Is.EqualTo(exp2));
            Assert.That(CodeKata_6.PrimeNumberConversion(input3, out output).Item3, Is.EqualTo(exp3));
        }

        [Test]
        public void PrimeNumberConversion_ReturnsCorrectNonePrimeString()
        {
            //Arrange
            string output = "";
            string input1 = "Nishant Mandal";
            string input2 = "015";
            string input3 = "";
            string exp1 = "Nishnt Mndl";
            string exp2 = "01";
            string exp3 = "";

            //Assert
            CodeKata_6.PrimeNumberConversion(input1, out output);
            Assert.That(output, Is.EqualTo(exp1));
            CodeKata_6.PrimeNumberConversion(input2, out output);
            Assert.That(output, Is.EqualTo(exp2));
            CodeKata_6.PrimeNumberConversion(input3, out output);
            Assert.That(output, Is.EqualTo(exp3));
        }

        [TestCase]
        public void PrimeNumberConversion_ReturnsCorrectDictionaryValues()
        {
            //Arrange
            Dictionary<char, int> expectedDictionary = new Dictionary<char, int>();
            expectedDictionary.Add('N', 78);
            expectedDictionary.Add('i', 105);
            expectedDictionary.Add('s', 115);
            expectedDictionary.Add('h', 104);
            expectedDictionary.Add('n', 110);
            expectedDictionary.Add('t', 116);
            expectedDictionary.Add(' ', 32);
            expectedDictionary.Add('M', 77);
            expectedDictionary.Add('d', 100);
            expectedDictionary.Add('l', 108);
            string output = "";
            string input = "Nishant Mandal";

            //Assert
            Assert.That(CodeKata_6.PrimeNumberConversion(input, out output).Item2, Is.EqualTo(expectedDictionary));
        }

        [TestCase(1, true)]
        [TestCase(4, false)]
        [TestCase(97, true)]
        [TestCase(100, false)]
        [TestCase('a', true)]
        [TestCase('b', false)]
        public void CheckIfNumberIsPrimeNumber_CorrectlyReturnsTrueFalse(int x, bool expected)
        {
            Assert.That(CodeKata_6.CheckIfNumberIsPrimeNumber(x), Is.EqualTo(expected));
        }
    }
}