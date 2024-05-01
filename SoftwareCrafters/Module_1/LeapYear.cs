namespace SoftwareCrafters.Module_1;

public class LeapYear
{
    public static bool LeapYearCalculator(int year)
        => year % 400 == 0 || year % 4 == 0 && year % 100 != 0;
}