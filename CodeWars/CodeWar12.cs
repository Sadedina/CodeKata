/*
 *                                  CodeWars Number 12
 *                                   I love big nums and I cannot lie
 *               https://www.codewars.com/kata/56121f3312baa28c8500005b/train/csharp
 */

namespace CodeWars;

public class CodeWar12
{
    #region ChatGPT performance (17.1370ms && 38.1370ms)
    public static string Biggest(int[] nums)
    {
        if (nums.All(n => n == 0)) return "0";

        return string.Join("", nums.Select(num => num.ToString())
            .OrderBy(x => x, new StringConcatenationComparer())
            .ToArray());
    }

    private class StringConcatenationComparer : IComparer<string>
    {
        public int Compare(string x, string y) => (y + x).CompareTo(x + y);
    }

    #endregion

    #region ChatGPT (16.1970ms && 40.0190ms)
    //public static string Biggest(int[] nums)
    //{
    //    if (nums.All(num => num == 0))
    //        return "0";

    //    var numStrings = nums.Select(num => num.ToString()).ToList();

    //    numStrings.Sort((x, y) => (y + x).CompareTo(x + y)); // Lexicographical comparison

    //    return string.Join("", numStrings);
    //}
    #endregion

    #region MyAttempt (31.4680ms && 211.0580ms)
    //public static string Biggest(int[] nums)
    //{
    //    if (nums.Sum() == 0)
    //        return "0";

    //    Array.Sort(nums);
    //    Array.Reverse(nums);
    //    var originalList = nums.ToList();

    //    var finalList = new List<int> { originalList.First() };
    //    originalList.RemoveAt(0);

    //    foreach (var originalItem in originalList)
    //    {
    //        foreach (var finalItem in finalList)
    //        {
    //            var isInsertable = OriginalBeforeFinal(originalItem, finalItem);
    //            var index = finalList.LastIndexOf(finalItem);

    //            if (isInsertable)
    //            {
    //                finalList.Insert(index, originalItem);
    //                break;
    //            }

    //            if (!isInsertable && index == finalList.Count - 1)
    //            {
    //                finalList.Insert(index + 1, originalItem);
    //                break;
    //            }
    //        }
    //    }

    //    return string.Join("", finalList);
    //}

    private static bool OriginalBeforeFinal(int originalItem, int finalItem)
    {
        var originalLength = GetLength(originalItem);
        var finalArray = SeparateIntoBucket(finalItem, originalLength);

        foreach (var finaleItem in finalArray)
        {
            var isSameLength = originalLength == GetLength(finaleItem);

            if (isSameLength && originalItem > finaleItem)
                return true;

            if (isSameLength && originalItem < finaleItem)
                return false;

            if (!isSameLength && OriginalBeforeFinal(finaleItem, originalItem))
                return false;
        }

        return true;
    }

    private static int GetLength(int number)
        => number.ToString()!.Length;

    private static int[] SeparateIntoBucket(int number, int length)
    {
        return number.ToString()
            .Select((digit, index) => new { digit, index })
            .GroupBy(x => x.index / length)
            .Select(g => int.Parse(new string(g.Select(x => x.digit).ToArray())))
            .ToArray();
    }
    #endregion
}