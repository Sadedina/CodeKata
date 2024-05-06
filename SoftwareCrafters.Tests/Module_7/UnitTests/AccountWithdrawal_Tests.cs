using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountWithdrawal_Tests
{
    [TestCase(300, 200, 100)]
    [TestCase(100, 200, -100)]
    public void Withdrawal_GivenAClientWithdrawal_DecreaseAmountFromBalance(
        decimal balance,
        decimal amount,
        decimal expectedBalance)
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client)
        {
            Balance = balance
        };

        var account = new Account(details);
        account.Withdrawal(amount);

        Assert.AreEqual(expectedBalance, details.Balance);
    }
}