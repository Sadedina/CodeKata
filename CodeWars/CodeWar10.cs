/*
 *                                  CodeWars Number 10
 *                                   Growing Plant
 *               https://www.codewars.com/kata/58941fec8afa3618c9000184/train/csharp
 */

namespace CodeWars;

public class CodeWar10
{
    public static int GrowingPlant(int upSpeed, int downSpeed, int desiredHeight)
    {
        var height = 0;
        var day = 0;

        while (height < desiredHeight)
        {
            height += upSpeed;

            day++;

            if (height >= desiredHeight)
            {
                break;
            }

            height -= downSpeed;
        }

        return day;
    }
}