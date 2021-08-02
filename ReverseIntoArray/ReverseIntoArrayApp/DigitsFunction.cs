using System;

namespace Solution
{
    public class Digitizer
    {
        public static long[] Digitize(long n)
        {
            string numb = Convert.ToString(n);
            int counter = numb.Length;
            long[] newArr = new long[counter];
            for (int i = 0; i < counter; i++)
            {
                newArr[i] = (long)(numb[counter- i -1]-48);
            }

            return newArr;
        }
    }
}