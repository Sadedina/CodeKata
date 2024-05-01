using System.Drawing;
/*
*                                  CodeKata Number 13
*                                  Pulsonix Assessment
*/

namespace PersonalDevelopment;

public class PD13
{
    //#######################################################################################
    // QUESTION 2 : PARENTHESIS MATCHING
    //
    // This is the skeleton of a function that takes a null-terminated string of text.
    // You are also given the index of a left or 'opening' parenthesis.
    //
    // For example:
    //
    // sentence = "When opening a door (for some reason (it could be any (real or imaginary) reason)) hold tight."
    // index  = --------------------------------------^
    //	
    // What the function should return is the index (from the beginning of the whole string)
    // of the corresponding (matching) right/closing parenthesis, or -1 if no matching 
    // parenthesis can be found. Write the code to complete this function.
    //
    // Also, explain how you would protect against bad input, and how you would test this
    // function once it is written.
    // Test in Test Project
    //#######################################################################################

    public static int FindMatchingParenthesis(string sentence, int index)
    {
        int positOfOpen = -1, positOfClose = 0;

        var numOpenBracket = sentence.Count(num => num == '(');
        var openBracket = new int?[numOpenBracket];
        var closeBracket = new int?[numOpenBracket];
        var onlyClosedBracket = new List<int>();

        if (sentence[index] != '(')
            throw new Exception($"The index given ({index}) does not correspond to '(' position but found '{sentence[index]}'.");

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == '(')
            {
                positOfOpen++;
                openBracket[positOfOpen] = i;
                positOfClose = positOfOpen;
                continue;
            }

            if (sentence[i] == ')')
            {
                if (positOfClose <= -1 || positOfOpen <= -1)
                {
                    onlyClosedBracket.Add(i);
                    continue;
                }

                var isSpaceEmpty = closeBracket[positOfClose] != null;

                while (isSpaceEmpty)
                {
                    positOfClose--;

                    if (positOfClose <= -1)
                    {
                        onlyClosedBracket.Add(i);
                        isSpaceEmpty = false;
                        continue;
                    }

                    isSpaceEmpty = closeBracket[positOfClose] != null;
                }

                if (positOfClose >= 0)
                {
                    closeBracket[positOfClose] = i;
                    positOfClose--;
                }
            }
        }

        int answer = Array.IndexOf(openBracket, index);

        if (closeBracket[answer] == null)
            return -1;

        if (answer != -1)
            return (int)closeBracket[answer];
        else
            return -1;
    }

    //#######################################################################################
    // QUESTION 4 : COLOURS
    //
    // Here is the skeleton for a function that takes the screen background colour
    // and a foreground colour to be used for drawing shapes on that background.
    // This function needs to work out an approximate colour to use for drawing those
    // items 'dimmed' so that they stand out less than items drawn in their normal colours.
    //
    // Write the missing code to calculate a value for the dimmed colour, given the 'full on'
    // foreground colour and the colour of the window background on which the item is drawn.
    //
    //#######################################################################################

    public static Color DimColour(Color foregroundColour, Color backgroundColour)
    {
        int foregroundRed = foregroundColour.R;
        int foregroundGreen = foregroundColour.G;
        int foregroundBlue = foregroundColour.B;

        // add implementation here to manipulate foreground colour elements
        // to produce a colour that appears dimmed on the screen relative
        // to something drawn in the original colour.
        foregroundRed = (foregroundRed + backgroundColour.R) / 2;
        foregroundGreen = (foregroundGreen + backgroundColour.G) / 2;
        foregroundBlue = (foregroundBlue + backgroundColour.B) / 2;

        // Finally, compose the adjusted colour elements back into a Windows colour.
        return Color.FromArgb(foregroundRed, foregroundGreen, foregroundBlue);
    }


    //#######################################################################################
    // QUESTION 6 : EFFICIENCY
    //
    // What things can you suggest to improve the efficiency of the code shown here?
    // There is nothing I would do to improve efficiency other than improve readibility

    #region Assessement Version
    public static int CountDigits(string text)
    {
        int Count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            string digits = "1234567890";

            if (digits.IndexOf(text[i]) != -1)
            {
                Count++;
            }
        }

        return Count;
    }
    #endregion

    public static int CountDigitsV2(string text)
    {
        const string digits = "1234567890";
        int Count = 0;

        for (int i = 0; i < text.Length; i++)
            if (digits.IndexOf(text[i]) != -1)
                Count++;

        return Count;
    }
    //#######################################################################################

    //#######################################################################################
    // QUESTION 7 : IDENTIFYING PROBLEMS
    //
    // This is a function that is intended to find the first occurrence of a given value
    // in an array of integers.
    //
    // What can you find in the code shown here that could cause unexpected results or
    // unintended behaviour?
    // If the counter is larger than array size, exception will be thrown.
    // Value returned if no match is found is zer and if value is 0 and present
    // in array it will also retun 0 
    // i needs to start from 0 or an array number will be missing

    #region Assessement Version
    public static int FindFirstMatchingValue(List<int> list, int count, int value)
    {
        var result = 0;

        for (int i = 1; i < count; i++)
        {
            if (list[i] == value)
            {
                int Result = i;
            }
        }

        return result;
    }
    #endregion

    public static (bool, int) FindFirstMatchingValueV2(List<int> list, int value)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            if (list[i] == value)
                return (true, i);
        }

        return (false, 0);
    }
    //#######################################################################################

    //#######################################################################################
    // QUESTION 8 : WHAT IS THE RESULT?
    //
    // What value is output?
    // 11

    private static int Calculate(int x, int y, int z)
    {
        x++;      // x = 1, y = 2, z = 3
        z = x + y;  // z = 3
        y += z;     // y = 5 
        return y;
    }

    public static int Mains()
    {
        var a = 1;
        var b = 2;
        var c = 3;

        var d = Calculate(a, b, c);

        Console.WriteLine(a + b + c + d);

        return 0;
    }
    //#######################################################################################

    //#######################################################################################
    // QUESTION 9 : INHERITANCE  
    //
    // What is the result of the code fragment below?
    //
    // A) prints out the value SHAPE
    // B) prints out the value BOX
    // C) prints out an undefined value
    // D) won't compile  <--------
    //

    public class Shape
    {
        Shape duplicate()
        {
            Console.WriteLine("SHAPE");
            return new Shape();
        }
    };

    public class Box : Shape
    {
        public Box() { }
        public Box duplicate()
        {
            Console.WriteLine("BOX");
            return new Box();
        }
    };

    public int main(int argc, char argv)
    {
        Shape s1 = new Box();
        //Shape s2 = s1.duplicate();
        return 0;
    }
    //#######################################################################################

    //#######################################################################################
    // QUESTION 10 : RECURSION
    //
    // Below is a simple function that takes an ordered array of numbers, and returns the
    // index of the first entry in that array that has the given value. If the requested
    // number is not in the array, it returns -1 to indicate failure.
    //
    // Write another function that uses recursion to perform the same task, and explain
    // why this is (or isn't) a better way than the first method.
    // Recursive function is not really applicable in this scenario
    // has it still has to loop through the list

    public static int findItemInList(List<int> list, int count, int value)
    {
        var found = -1;
        for (var index = 0; index < count && found < 0; index++)
        {
            if (list[index] == value)
            {
                found = index;
            }
        }
        return found;
    }

    int main()
    {
        var numbers = new List<int> { 2, 2, 3, 5, 6, 8, 14, 16, 22, 22, 30, 36 };
        var howMany = 12;

        return findItemInList(numbers, howMany, 22);
    }
    //#######################################################################################
}