﻿using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Module_7;

public interface IAccount
{
    public decimal GetBalance();
    public void Deposit(decimal amount);
    public void Withdrawal(decimal amount);
}

public class Account : IAccount
{
    private readonly Client client;
    private decimal balance;
    private List<string> log = new();

    public Account(Client client) => this.client = client;

    public List<string> Log => log;

    public decimal GetBalance() => balance;

    public void Deposit(decimal amount)
    {
        var hasExceededAccountLimit = balance + amount > 3000000000;

        if (hasExceededAccountLimit)
        {
            log.Add($"Warning: You can not make the deposit of £ {amount}, due to exceeding the maximum account balance of £ 3,000,000,000!");
            return;
        }

        balance += amount;
    }

    public void Withdrawal(decimal amount)
    {
        var hasExceededAccountLimit = balance - amount < -1000;

        if (hasExceededAccountLimit)
        {
            log.Add($"Warning: You can not make the withdrawal of £ {amount}, due to exceeding the minimum account balance of £ -1000!");
            return;
        }

        balance -= amount;
    }

    //public string UniqueIdentifier => CreateUniqueClientNumber();

    //private string CreateUniqueClientNumber()
    //{
    //    var identifier = client.Title.First() +
    //        client.FirstName.First() +
    //        client.LastName.First() +
    //        client.Age.GetValueOrDefault() +
    //        Guid.NewGuid().ToString();

    //    return identifier.Substring(0, 10);
    //}
}