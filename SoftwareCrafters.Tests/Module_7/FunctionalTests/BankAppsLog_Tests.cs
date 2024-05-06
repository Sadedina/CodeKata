using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsLog_Tests : Fixture
{
    [Test]
    public void GivenAClientWithAnAccount_WhenTheClientMakesExceedingDeposit_ThenLogsShouldBeUpdated()
    {
        var details = CreateAnAcountDetailWithBalance(500);
        var deposit = 3000000001;
        var loggedMessage = $"Warning: You can not make the deposit of £ 3000000001, due to exceeding the maximum account balance of £ 3,000,000,000!";

        this.Given(_ => AClientWithAnAccount(details))
            .When(_ => ClientMakesADeposit(deposit))
            .Then(_ => LogsShouldBeUpdated(details, loggedMessage))
        .BDDfy();
    }

    private void ClientMakesADeposit(decimal amount) => bankApps.DepositIntoAccount(amount, DateTime.Now);

    private void LogsShouldBeUpdated(AccountDetails details, string loggedMessage)
        => bankApps.GetLogs().Should().ContainEquivalentOf(loggedMessage);
}