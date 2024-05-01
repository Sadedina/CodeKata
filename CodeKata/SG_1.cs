/*
*                                  CodeKata Number 0.1
*             
* Return the remainder of a number in sets of: 
* £0.01, £0.02, £0.05, £0.10, £0.20, £0.50, £1.00, £2.00, £5.00, £10.00, £20.00, £50.00
* 
*/
namespace SpartaGlobal;

public class SG_1
{
    public static Dictionary<string, int> AnswerOfRemainder(decimal remainder)
    {
        var list = new Dictionary<string, int>();

        string[] currency = { "£50.00", "£20.00", "£10.00", "£5.00", "£2.00", "£1.00", "£0.50", "£0.20", "£0.10", "£0.05", "£0.02", "£0.01" };
        decimal[] money = { 50, 20, 10, 5, 2, 1, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

        int division;
        int position = 0;

        while (remainder > 0)
        {
            division = (int)(remainder / money[position]);
            list.TryAdd(currency[position], division);
            remainder -= money[position] * division;
            position++;
        }

        return list;
    }
}