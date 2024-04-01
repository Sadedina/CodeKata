/*
*                                  CodeWars Number 7
*                                Cat years, Dog years
*               https://www.codewars.com/kata/5a6663e9fd56cb5ab800008b/train/csharp
*                                Cat Years, Dog Years (2)
*               https://www.codewars.com/kata/5a6d3bd238f80014a2000187
*/

namespace CodeWars;

public static class CodeWar_7
{
    #region Cat years, Dog years
    public static int[] HumanYearsCatYearsDogYears(int humanYears)
    {
        if (humanYears == 1)
            return new[] { 1, 15, 15 };

        if (humanYears == 2)
            return new[] { 2, 24, 24 };

        var catYears = 24 + 4 * (humanYears - 2);
        var dogYears = 24 + 5 * (humanYears - 2);

        return new[] { humanYears, catYears, dogYears };
    }
    #endregion

    #region Cat years, Dog years (2)
    public static (int, int) OwnedCatAndDog(int catYears, int dogYears)
        => (ConvertCatYears(catYears), ConvertDogYears(dogYears));

    private static int ConvertCatYears(int catYears)
    {
        if (catYears < 15)
            return 0;

        if (catYears is >= 15 and < 24)
            return 1;

        if (catYears is >= 24 and < 28)
            return 2;

        return (catYears - 24) / 4 + 2;
    }

    private static int ConvertDogYears(int dogYears)
    {
        if (dogYears < 15)
            return 0;

        if (dogYears is >= 15 and < 24)
            return 1;

        if (dogYears is >= 24 and < 29)
            return 2;

        return (dogYears - 24) / 5 + 2;
    }
    #endregion
}