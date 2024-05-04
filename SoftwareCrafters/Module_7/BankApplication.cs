namespace SoftwareCrafters.Module_7;

public interface IBankApplication
{
    public void Transfer(IAccount accountA, IAccount accountB, decimal amount);
}

public class BankApplication : IBankApplication
{
    public void Transfer(IAccount accountA, IAccount accountB, decimal amount)
    {
        accountA.Withdrawal(amount);
        accountB.TransferDeposit(amount);

        var log = accountB.GetExternalLog();
        if (!string.IsNullOrEmpty(log))
        {
            accountA.AddExternalLog(log);
            accountA.Deposit(amount);
        }
    }
}