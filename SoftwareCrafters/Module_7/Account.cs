using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Module_7;

public interface IAccount
{
    public decimal GetBalance();
    public List<string[]> GetStatement();
    public List<string> GetLog();
    public void AddStatement(Statement statement);
    public void AddLog(string message);
    public void Deposit(decimal amount);
    public void Withdrawal(decimal amount);
}

public class Account : IAccount
{
    private readonly AccountDetails details;

    public Account(AccountDetails details) => this.details = details;

    public decimal GetBalance() => details.Balance;

    public List<string[]> GetStatement()
    {
        var statement = details.Statements;
        statement.Reverse();
        return statement;
    }

    public List<string> GetLog() => details.Logs;

    public void AddStatement(Statement statement) => details.AddStatement(statement);

    public void AddLog(string message) => details.AddLog(message);

    public void Deposit(decimal amount) => details.Balance += amount;

    public void Withdrawal(decimal amount) => details.Balance -= amount;
}