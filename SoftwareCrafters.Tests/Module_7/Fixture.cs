using FluentAssertions;
using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class Fixture
{
    internal Account Account { get; set; }

    internal void AClientOpensANewAccount()
    {
        var client = new Client("Dr", "Jack", "Smith");
        Account = new Account(client);
    }

    internal void AClientHasAnExistingAccountWithABalance(decimal expectedBalance)
    {
        var client = new Client("Dr", "Jack", "Smith");
        Account = new Account(client);
        Account.Deposit(expectedBalance);
    }

    internal void ClientShouldHaveAnAccountBalance(decimal expectedBalance)
        => Account.GetBalance().Should().Be(expectedBalance);

    internal void DepositShouldBeRejected(string message) => Account.Log.Should().ContainEquivalentOf(message);
}