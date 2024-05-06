using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountDeposit_Tests
{
    [TestCase(0, 1000, 1000)]
    [TestCase(0, 2000, 2000)]
    [TestCase(0, 0.50, 0.50)]
    [TestCase(0, 2150000000.00, 2150000000.00)]
    [TestCase(500, 150, 650)]
    public void Deposit_GivenAClientDeposit_AddsAmountToBalance(
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
        account.Deposit(amount);

        Assert.AreEqual(expectedBalance, details.Balance);
    }

    [Test]
    public void Deposit_GivenAClientMakesMultipoleDeposit_AddsAllDepositToBalance()
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client);
        var expectedBalance = 700;

        var account = new Account(details);
        account.Deposit(500);
        account.Deposit(200);

        Assert.AreEqual(expectedBalance, details.Balance);
    }
}