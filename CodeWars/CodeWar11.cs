/*
 *                                  CodeWars Number 11
 *                                   Cats in hats
 *               https://www.codewars.com/kata/57b5907920b104772c00002a/train/csharp
 */

using System.Globalization;

namespace CodeWars;

public class CodeWar11
{
    public static string Height(int n)
    {
        double height = 2000000;
        double total = 0;

        for (int i = 0; i < n + 1; i++)
        {
            total += height;
            height /= 2.5;
        }

        return total.ToString("F3", CultureInfo.InvariantCulture);
    }
}