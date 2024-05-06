using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Module_7;

public class BankApps
{
    private readonly IAccount account;

    public BankApps(AccountDetails details) => account = new Account(details);

    public decimal GetBalanceFromAccount() => account.GetBalance();

    public List<string[]> GetStatement()
    {
        var statement = account.GetStatement();
        statement.Reverse();
        return statement;
    }

    public List<string> GetLogs() => account.GetLog();

    public void DepositIntoAccount(decimal amount, DateTime date)
    {
        var hasExceededAccountLimit = account.GetBalance() + amount > 3000000000;

        if (hasExceededAccountLimit)
        {
            account.AddLog($"Warning: You can not make the deposit of £ {amount}, due to exceeding the maximum account balance of £ 3,000,000,000!");
            return;
        }

        account.Deposit(amount);
        CreateStatement(date, amount, null);
    }

    public void WithdrawalFromAccount(decimal amount, DateTime date)
    {
        var hasExceededAccountLimit = account.GetBalance() - amount < -1000;

        if (hasExceededAccountLimit)
        {
            account.AddLog($"Warning: You can not make the withdrawal of £ {amount}, due to exceeding the minimum account balance of £ -1000!");
            return;
        }

        account.Withdrawal(amount);
        CreateStatement(date, null, amount);
    }

    public void TransferIntoAccount(AccountDetails transfereeDetails, decimal amount, DateTime date)
    {
        var hasExceededAccountLimit = transfereeDetails.Balance + amount > 3000000000;

        if (hasExceededAccountLimit)
        {
            account.AddLog($"Warning: You can not make the transfer of £ {amount}, as {transfereeDetails.Client} will exceed the maximum account balance on the account!");
            return;
        }

        account.Withdrawal(amount);
        CreateStatement(date, null, amount);

        var transfreeAccount = new Account(transfereeDetails);
        transfreeAccount.Deposit(amount);

        var statement = new Statement(date, amount, null, account.GetBalance());
        transfreeAccount.AddStatement(statement);
    }

    private void CreateStatement(DateTime date, decimal? credit, decimal? debit)
    {
        var statement = new Statement(date, credit, debit, account.GetBalance());
        account.AddStatement(statement);
    }
}