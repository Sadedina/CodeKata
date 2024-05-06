namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsWithdrawal_Tests : Fixture
{
    [TestCase(300, 200, 100)]
    [TestCase(100, 200, -100)]
    public void GivenAClientHasAnExistingAccountWithABalance_WhenTheClientMakesAWithdrawal_ThenTheClientShouldHaveANewAccountBalance(
        decimal balance,
        decimal amaount,
        decimal expectedBalance)
    {
        var details = CreateAnAcountDetailWithBalance(balance);

        this.Given(_ => AClientWithAnAccount(details))
            .When(_ => ClientMakesAWithdrawal(amaount))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
            .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesAWithdrawalOf1001_ThenTheWithdrawalShouldBeRejected_AndTheClientShouldBeToldTheyCanNotExceedOverdraftOf1000()
    {
        var withdrawal = 1001;
        var details = CreateAnAcountDetailWithBalance();
        var balance = details.Balance;
        var loggedMessage = $"Warning: You can not make the withdrawal of £ 1001, due to exceeding the minimum account balance of £ -1000!";

        this.Given(_ => AClientWithAnAccount(details))
            .When(_ => ClientMakesAWithdrawal(withdrawal))
            .Then(_ => DepositShouldBeRejected(details, loggedMessage))
                .And(_ => ClientShouldHaveAnAccountBalance(balance))
        .BDDfy();
    }

    private void ClientMakesAWithdrawal(decimal amount) => bankApps.WithdrawalFromAccount(amount);
}