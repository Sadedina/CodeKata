using System;
using System.Collections.Generic;

/*
*                                  CodeKata Number 0.5
* 
* Transform integers into Roman numerals 
*/
namespace CodeKata
{
    public class CodeKata_0_5
    {
        public static string IntoRomanNumerals(int num)
        {
            string[] fix = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            string[] prefix = {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] beforePrefix = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM", "M" };
            var romanNumber = "";
            var numString = Convert.ToString(num);

            if (num < 10)           romanNumber = fix[num];
            else if (num < 100)     romanNumber = prefix[numString[0] - 48] + fix[numString[1] - 48];
            else if (num < 1000)    romanNumber = beforePrefix[numString[0] - 48] + prefix[numString[1] - 48] + fix[numString[2] - 48];
            else if (num < 2000)    romanNumber = "M" + beforePrefix[numString[1] - 48] + prefix[numString[2] - 48] + fix[numString[3] - 48];

            return romanNumber;
        }
    }
}