/*
 *                                  CodeWars Number 13
 *                                   Cuckoo Clock
 *               https://www.codewars.com/kata/656e4602ee72af0017e37e82/train/csharp
 */

namespace CodeWars;

public class CodeWar13
{
    public static string CuckooClock(string inputTime, int chimes)
    {
        var originalTime = TransformTime(inputTime);
        var transformedTime = ClosestCuckooTime(originalTime);
        var transformedChimes = TransformChimes(chimes, originalTime);
        var finalTime = FindCurrentTime(transformedTime, transformedChimes);

        return TransformTime(finalTime);
    }

    private static int[] TransformTime(string inputTime)
    {
        var time = inputTime.Split(':');

        var hour = int.Parse(time[0]);
        var minute = int.Parse(time[1]);

        return new[] { hour, minute };
    }

    private static int[] ClosestCuckooTime(int[] inputTime)
    {
        if (inputTime[1] < 15)
            return new[] { inputTime[0], 0 };

        if (inputTime[1] < 30)
            return new[] { inputTime[0], 15 };

        if (inputTime[1] < 45)
            return new[] { inputTime[0], 30 };

        return new[] { inputTime[0], 45 };
    }

    private static int TransformChimes(int chimes, int[] originalTime)
    {
        if (originalTime[1] is 15 or 30 or 45)
            return chimes - 1;

        if (originalTime[1] is 0)
            return chimes - originalTime[0];

        return chimes;
    }

    private static int[] FindCurrentTime(int[] transformedTime, int chimes)
    {
        var hour = transformedTime[0];
        var minute = transformedTime[1];

        while (chimes > 0)
        {
            if (hour is 12 && minute is 45)
                hour = 0;

            if (minute is 45)
            {
                hour += 1;
                minute = 0;

                chimes -= hour;
                continue;
            }

            minute += 15;
            chimes -= 1;
        }

        return new[] { hour, minute };
    }

    private static string TransformTime(int[] finalTime)
    {
        var hour = finalTime[0].ToString();
        var minute = finalTime[1].ToString();

        if (finalTime[0] < 10)
            hour = $"0{hour}";

        if (finalTime[1] < 10)
            minute = $"0{minute}";

        return $"{hour}:{minute}";
    }
}