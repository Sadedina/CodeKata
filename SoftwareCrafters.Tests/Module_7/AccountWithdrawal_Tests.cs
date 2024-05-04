namespace SoftwareCrafters.Tests.Module_7;

public class AccountWithdrawal_Tests : Fixture
{
    [TestCase(300, 200, 100)]
    [TestCase(100, 200, -100)]
    public void GivenAClientHasAnExistingAccountWithABalance_WhenTheClientMakesAWithdrawal_ThenTheClientShouldHaveANewAccountBalance(
        decimal balance,
        decimal withdrawal,
        decimal expectedBalance)
    {
        this.Given(_ => AClientHasAnExistingAccountWithABalance(balance))
                .And(_ => ClientMakesAWithdrawal(withdrawal))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesAWithdrawalOf1001_ThenTheWithdrawalShouldBeRejected_AndTheClientShouldBeToldTheyCanNotExceedOverdraftOf1000()
    {
        var withdrawal = 1001;
        var loggedMessage = $"Warning: You can not make the withdrawal of £ 1001, due to exceeding the minimum account balance of £ -1000!";
        var balance = 0;

        this.Given(_ => AClientOpensANewAccount())
            .And(_ => ClientMakesAWithdrawal(withdrawal))
            .Then(_ => DepositShouldBeRejected(loggedMessage))
                .And(_ => ClientShouldHaveAnAccountBalance(balance))
        .BDDfy();
    }

    private void ClientMakesAWithdrawal(decimal withdrawal) => Account.Withdrawal(withdrawal);
}