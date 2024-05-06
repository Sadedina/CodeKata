namespace SoftwareCrafters.Module_7.Models;

public record Statement
{
    private readonly DateTime date;
    private readonly decimal? credit;
    private readonly decimal? debit;
    private readonly decimal balance;

    public Statement(
        DateTime date,
        decimal? credit,
        decimal? debit,
        decimal balance)
    {
        this.date = date;
        this.credit = credit;
        this.debit = debit;
        this.balance = balance;
    }

    public string[] ToArray()
    {
        var parsedDate = DateParser(date);
        var parsedCredit = DecimalParser(credit);
        var parsedDebit = DecimalParser(debit);
        var parsedBalance = DecimalParser(balance);

        return new[] { parsedDate, parsedCredit, parsedDebit, parsedBalance };
    }

    private static string DateParser(DateTime date)
    {
        var day = ParseNumber(date.Day);
        var month = ParseNumber(date.Month);
        var year = ParseNumber(date.Year);

        return $"{day}/{month}/{year}";
    }

    private static string ParseNumber(int number)
    {
        if (number < 10)
            return $"0{number}";

        return number.ToString();
    }

    private static string DecimalParser(decimal? amount)
    {
        if (amount is null)
            return "0.00";

        return string.Format("{0:0.00}", amount);
    }
}