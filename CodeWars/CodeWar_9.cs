/*
 *                                  CodeWars Number 9
 *                                   Sort the odd
 *               https://www.codewars.com/kata/578aa45ee9fd15ff4600090d/train/csharp
 */

namespace CodeWars;

public class CodeWar_9
{
    public static int[] SortArray(int[] array)
    {
        var extractOdds = ExtractOddNumbers(array);
        var rearrangeOdds = RearrangeOddNumbers(extractOdds);

        var oddNumberCounter = 0;
        var answer = new List<int>();

        foreach (var number in array)
        {
            if (number % 2 == 0)
            {
                answer.Add(number);
            }
            else
            {
                answer.Add(rearrangeOdds[oddNumberCounter]);
                oddNumberCounter++;
            }
        }

        return answer.ToArray();
    }

    public static int[] ExtractOddNumbers(int[] array)
        => array.Where(n => n % 2 != 0).ToArray();

    public static int[] RearrangeOddNumbers(int[] array)
    {
        Array.Sort(array);

        return array;
    }

}