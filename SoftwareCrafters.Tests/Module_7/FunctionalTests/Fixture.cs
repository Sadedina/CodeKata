using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class Fixture
{
    internal BankApps bankApps;

    internal static AccountDetails CreateAnAcountDetailWithBalance(decimal amount = 0)
    {
        var client = new Client("Dr.", "Jack", "Smith");

        return new(client) { Balance = amount };
    }

    internal static decimal GetBalance(AccountDetails details)
        => details.Balance;

    internal void AClientWithAnAccount(AccountDetails details)
        => bankApps = new BankApps(details);

    internal void ClientShouldHaveAnAccountBalance(decimal expectedBalance)
        => bankApps.GetBalanceFromAccount();

    internal static void DepositShouldBeRejected(AccountDetails details, string message)
        => details.Logs.Should().ContainEquivalentOf(message);
}