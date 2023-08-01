/*
*                                  CodeWars Number 2
*                                  What century is it?
*           https://www.codewars.com/kata/52fb87703c1351ebd200081f/train/csharp
*/

namespace CodeWars
{
    public class CodeWar_2
    {
        public static string WhatCentury(string year)
            => WithSuffix(Math.Ceiling((decimal)Int32.Parse(year) / 100).ToString());

        private static string WithSuffix(string century)
        {
            var suffix = "th";

            if (century.EndsWith("1") && !century.EndsWith("11"))
                suffix = "st";

            if (century.EndsWith("2") && !century.EndsWith("12"))
                suffix = "nd";

            if (century.EndsWith("3") && !century.EndsWith("13"))
                suffix = "rd";

            return century + suffix;
        }
    }
}