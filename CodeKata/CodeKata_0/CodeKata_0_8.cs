using System;
using System.Threading;

/*
*                                  CodeKata Number 0.8
*                                       Calculator
*/
namespace CodeKata
{
    public class CodeKata_0_8
    {
        public static void Modes()
        {
            string mode = "";
            do
            {
                mode = Calculator().ToLower();
            }while(!mode.Contains("7") && !mode.Contains("ex"));
        }
        public static string Calculator()
        {
            Console.Clear();
            Console.WriteLine("===== Welcome to Calculator mode =====");
            Console.Write("Please input a mode:\n1. Addition Mode\n2. Subtraction Mode\n" +
                "3. Multiplication Mode\n4. Division Mode\n5. To the Power Moden\n6. Square Root Mode\n" +
                "7. Exit\n\nInput: ");
            string mode = Console.ReadLine().ToLower();
            Console.Clear();

            if (mode.Contains("1") || mode.Contains("add"))
            {
                Console.Write("===== Welcome to Addition Mode =====\nInput First digit: ");
                decimal num1 = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Input Second digit: ");
                decimal num2 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"\nANSWER\n{num1} + {num2} = {Addition(num1, num2)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("2") || mode.Contains("sub"))
            {
                Console.Write("===== Welcome to Subtraction Mode =====\nInput First digit: ");
                decimal num1 = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Input Second digit: ");
                decimal num2 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"\nANSWER\n{num1} - {num2} = {Subtraction(num1, num2)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("3") || mode.Contains("mult"))
            {
                Console.Write("===== Welcome to Multiplication Mode =====\nInput First digit: ");
                decimal num1 = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Input Second digit: ");
                decimal num2 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"\nANSWER\n{num1} * {num2} = {Multiplication(num1, num2)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("4") || mode.Contains("divi"))
            {
                Console.Write("===== Welcome to Division Mode =====\nInput First digit: ");
                decimal num1 = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Input Second digit: ");
                decimal num2 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"\nANSWER\n{num1} / {num2} = {Division(num1, num2)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("5") || mode.Contains("pow"))
            {
                Console.Write("===== Welcome to The Power Mode =====\nInput First digit: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Input Second digit: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"\nANSWER\n{num1} ^ {num2} = {Power(num1, num2)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("6") || mode.Contains("sq") || mode.Contains("root"))
            {
                Console.WriteLine("===== Welcome to Square Root Mode =====\nInput digit: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"\nANSWER\nSquare root of {num1} = {Sqrt(num1)}");
                Thread.Sleep(3000);
            }
            else if (mode.Contains("7") || mode.Contains("ex"))
            {
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Your input was invalid!");
                Thread.Sleep(1000);
            }

            return mode;
        }

        public static decimal Addition(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
        public static decimal Subtraction(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
        public static decimal Multiplication(decimal num1, decimal num2)
        {
            return num1 * num2;
        }
        public static decimal Division(decimal num1, decimal num2)
        {
            if (num2 == 0) throw new Exception("Cannot divide by Zero!");
            return num1 / num2;
        }
        public static double Power(double num1, double num2)
        {
            if (num1 == 0 && num2 <= 0) throw new Exception("Cannot divide by Zero!");
            return Math.Pow(num1, num2);
        }
        public static double Sqrt(double num1)
        {
            if (num1 < 0) throw new Exception("Cannot Square Root a negative number!");
            return Math.Sqrt(num1);
        }
    }
}