using System;
using System.Collections.Generic;

/*
*                                  CodeKata Number 0.4
*                                    (C# Basic Test)
*                        Digits composed with more than 2 intergers 
* 
* Return 1 if digits composed is more than 2 integers
* Return -1 if digits composed is 2 or less integers   
* 
* Example
* 103 returns -1
* 9 returns 1
*/
namespace CodeKata
{
    public class CodeKata_0_4
    {
        public static int Composed(string num)
        {
            //  Convert.ToInt32(num)        Can be used to convert string into integer
            bool conversionNotSuccesful = !(Int32.TryParse(num, out int num1));
            int numero1 = 0, numero2 = 0, numero3 = 0, numero4 = 0, numero5 = 0, numero6 = 0, numero7 = 0, numero8 = 0, numero9 = 0, numero0 = 0;

            if (conversionNotSuccesful)
            {
                throw new ArgumentException("String is not an Integer");
            }

            if (num[0] == '-' || num[0] == '+')
            {
                num = num.Remove(0, 1);
            }

            int value = Convert.ToInt32(num);

            for (int i = 0; i < num.Length; i++)
            {
                switch (num[i])
                {
                    case '1':
                        numero1++;
                        break;
                    case '2':
                        numero2++;
                        break;
                    case '3':
                        numero3++;
                        break;
                    case '4':
                        numero4++;
                        break;
                    case '5':
                        numero5++;
                        break;
                    case '6':
                        numero6++;
                        break;
                    case '7':
                        numero7++;
                        break;
                    case '8':
                        numero8++;
                        break;
                    case '9':
                        numero9++;
                        break;
                    default:
                        numero0++;
                        break;
                }
            }

            int[] count = { numero0, numero1, numero2, numero3, numero4, numero5, numero6, numero7, numero8, numero9 };
            int numZeros = 0;

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] == 0)
                {
                    numZeros++;
                }
            }

            int result = -1;
            if (numZeros >= 8)
            {
                result = 1;
            }

            return result;
        }

        public static int Composed_2(string num)
        {
            //  Convert.ToInt32(num)        Can be used to convert string into integer
            bool conversionNotSuccesful = !(Int32.TryParse(num, out int num1));


            if (conversionNotSuccesful)
            {
                throw new ArgumentException("String is not an Integer");
            }

            if (num[0] == '-' || num[0] == '+')
            {
                num = num.Remove(0, 1);
            }

            int value = Convert.ToInt32(num);
            int[] count = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < num.Length; i++)
            {
                int a = (int)num[i] - 48;       // Conversion from ASCII Table
                count[a]++;
            }

            int numZeros = 0;

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] == 0)
                {
                    numZeros++;
                }
            }

            int result = -1;
            if (numZeros >= 8)
            {
                result = 1;
            }

            return result;
        }
    }
}