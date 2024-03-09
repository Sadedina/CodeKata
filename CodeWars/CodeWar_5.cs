/*
*                                  CodeWars Number 5
*                                CamelCase to underscore
*                   https://www.codewars.com/kata/5b1956a7803388baae00003a
*/

namespace CodeWars;

public static class CodeWar_5
{
    public static string ToUnderScore(string name)
    {
        name = name.Replace(" ", "");

        if (string.IsNullOrEmpty(name))
            return "";

        var nameLength = name.Length;

        for (int i = 0; i < nameLength - 1; i++)
        {
            var j = i + 1;

            var previousValue = ConvertToValue(name[i]);
            var nextValue = ConvertToValue(name[j]);

            var nextValueIsUppercase = nextValue == 2 && previousValue != 0;
            var nextValueIsNumber = nextValue == 1 && previousValue == 3;

            var shouldAddUnderscore = nextValueIsUppercase || nextValueIsNumber;

            if (shouldAddUnderscore)
            {
                name = name.Insert(j, "_");
                nameLength++;
            }
        }

        return name.Replace("__", "_");
    }

    private static int ConvertToValue(char letter)
    {
        // 0 = Symbol; 1 = Number; 2 = Uppercase; 3 = LowerCase

        if (Int32.TryParse(letter.ToString(), out int i))
            return 1;

        if (char.IsUpper(letter))
            return 2;

        if (char.IsLower(letter))
            return 3;

        return 0;
    }
}