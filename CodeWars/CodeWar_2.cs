/*
*                                  CodeWars Number 2
*                                  What century is it?
*           https://www.codewars.com/kata/52fb87703c1351ebd200081f/train/csharp
*
*           https://www.codewars.com/kata/52685f7382004e774f0001f7
*/

namespace CodeWars
{
    public class CodeWar_2
    {
        #region What century is it?
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


        #endregion

        #region Human Readable Time
        public static string GetReadableTime(int seconds)
        {
            var (hour, secondsMinusHour) = HoursToString(seconds);
            var (minutes, secondsMinusMinutes) = MinutesToString(secondsMinusHour);
            var second = (int)Math.Floor(secondsMinusMinutes);

            var hrs = hour.ToString();
            var mins = minutes.ToString();
            var sec = second.ToString();

            var (ora, minuti, secondi) = FormatTime(hrs, mins, sec);

            return $"{ora}:{minuti}:{secondi}";
        }

        private static (int, decimal) HoursToString(decimal seconds)
        {
            var hrs = Math.Floor(seconds / 3600);
            seconds -= hrs * 3600;

            return ((int)hrs, seconds);
        }

        private static (int, decimal) MinutesToString(decimal seconds)
        {
            var mins = Math.Floor(seconds / 60);
            seconds -= mins * 60;

            return ((int)mins, seconds);
        }

        private static (string, string, string) FormatTime(
            string hrs,
            string mins,
            string sec)
        {
            if (hrs.Length == 1)
                hrs = $"0{hrs}";

            if (mins.Length == 1)
                mins = $"0{mins}";

            if (sec.Length == 1)
                sec = $"0{sec}";

            return (hrs, mins, sec);
        }
        #endregion
    }
}