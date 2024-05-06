using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Module_7;

public interface IAccount
{
    public decimal GetBalance();
    public void Deposit(decimal amount);
    public void Withdrawal(decimal amount);
}

public class Account : IAccount
{
    private readonly AccountDetails details;

    public Account(AccountDetails details) => this.details = details;

    public decimal GetBalance() => details.Balance;

    public void Deposit(decimal amount) => details.Balance += amount;

    public void Withdrawal(decimal amount) => details.Balance -= amount;
}