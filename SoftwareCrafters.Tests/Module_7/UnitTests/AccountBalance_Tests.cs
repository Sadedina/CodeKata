using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.UnitTests;

public class AccountBalance_Tests
{
    [TestCase(0)]
    [TestCase(10)]
    [TestCase(100)]
    public void GetBalance_ReturnBalanceOfAccount(decimal amount)
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client)
        {
            Balance = amount
        };
        var expectedBalance = amount;

        var account = new Account(details);
        var balance = account.GetBalance();

        Assert.AreEqual(expectedBalance, balance);
    }
}