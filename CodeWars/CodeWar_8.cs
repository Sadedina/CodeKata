/*
 *                                  CodeWars Number 8
 *                                 Mount the Bowling Pins!
 *               https://www.codewars.com/kata/585cf93f6ad5e0d9bf000010/train/csharp
 */
namespace CodeWars;

public class CodeWar_8
{
    //          7 8 9 10
    //           4 5 6
    //            2 3
    //             1

    // returning string => "I I I I\n I I I \n  I I  \n   I   "
    private static Dictionary<int, string> pins = new();

    public string BowlingPins(int[] arr)
    {
        ResetBowlingPins();
        RemoveFallenPins(arr.ToList());
        return PinsToString();
    }

    private static void ResetBowlingPins()
    {
        pins.Clear();

        for (var bowling = 1; bowling <= 10; bowling++)
            pins.Add(bowling, "I");
    }

    private static void RemoveFallenPins(List<int> bowling)
    {
        foreach (var pin in bowling)
            pins[pin] = " ";
    }

    private static string PinsToString()
        => $"{pins[7]} {pins[8]} {pins[9]} {pins[10]}\n {pins[4]} {pins[5]} {pins[6]} \n  {pins[2]} {pins[3]}  \n   {pins[1]}   ";

    #region Attempt1
    private static string BowlingPinTester(List<int> list)
    {
        var bowls = "";

        if (list.Contains(7))
        {
            bowls += "  ";
        }
        else
        {
            bowls += "I ";
        }

        if (list.Contains(8))
        {
            bowls += "  ";
        }
        else
        {
            bowls += "I ";
        }

        if (list.Contains(9))
        {
            bowls += "  ";
        }
        else
        {
            bowls += "I ";
        }

        if (list.Contains(10))
        {
            bowls += " \n";
        }
        else
        {
            bowls += "I\n";
        }

        if (list.Contains(4))
        {
            bowls += "  ";
        }
        else
        {
            bowls += " I";
        }

        if (list.Contains(5))
        {
            bowls += "  ";
        }
        else
        {
            bowls += " I";
        }

        if (list.Contains(6))
        {
            bowls += "   \n";
        }
        else
        {
            bowls += " I \n";
        }

        if (list.Contains(2))
        {
            bowls += "    ";
        }
        else
        {
            bowls += "  I ";
        }

        if (list.Contains(3))
        {
            bowls += "   \n";
        }
        else
        {
            bowls += "I  \n";
        }

        if (list.Contains(1))
        {
            bowls += "       ";
        }
        else
        {
            bowls += "   I   ";
        }

        return bowls;
    }
    #endregion
}