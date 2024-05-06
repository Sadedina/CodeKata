using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Module_7;

public class BankApps
{
    private readonly AccountDetails details;
    private readonly IAccount account;

    public BankApps(AccountDetails details)
    {
        this.details = details;
        account = new Account(details);
    }

    public decimal GetBalanceFromAccount() => account.GetBalance();
    public void DepositIntoAccount(decimal amount)
    {
        var hasExceededAccountLimit = details.Balance + amount > 3000000000;

        if (hasExceededAccountLimit)
        {
            details.AddIntoLog($"Warning: You can not make the deposit of £ {amount}, due to exceeding the maximum account balance of £ 3,000,000,000!");
            return;
        }

        account.Deposit(amount);
    }

    public void WithdrawalFromAccount(decimal amount)
    {
        var hasExceededAccountLimit = details.Balance - amount < -1000;

        if (hasExceededAccountLimit)
        {
            details.AddIntoLog($"Warning: You can not make the withdrawal of £ {amount}, due to exceeding the minimum account balance of £ -1000!");
            return;
        }

        account.Withdrawal(amount);
    }

    public void TransferIntoAccount(AccountDetails transfereeDetails, decimal amount)
    {
        var hasExceededAccountLimit = transfereeDetails.Balance + amount > 3000000000;

        if (hasExceededAccountLimit)
        {
            details.AddIntoLog($"Warning: You can not make the transfer of £ {amount}, as {transfereeDetails.Client} will exceed the maximum account balance on the account!");
            return;
        }

        account.Withdrawal(amount);
        var transfreeAccount = new Account(transfereeDetails);
        transfreeAccount.Deposit(amount);
    }
}