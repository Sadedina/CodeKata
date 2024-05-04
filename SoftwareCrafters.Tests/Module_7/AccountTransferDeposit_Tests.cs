using FluentAssertions;
using SoftwareCrafters.Module_7;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountTranferDeposit_Tests : Fixture
{
    [Test]
    public void GivenAClientOpensANewAccount_WhenTheyRecieveADeposit_ThenTheClientShouldHaveANewAccountBalance()
    {
        var deposit = 1000;

        this.Given(_ => AClientOpensANewAccount())
            .When(_ => ClientRecievesATransferDeposit(deposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(deposit))
            .BDDfy();
    }

    [Test]
    public void GivenAClientHasAnExistingAccountWithABalanceOf500_WhenTheyRecieveADepositOf150_ThenTheClientShouldHaveANewAccountBalanceOf650()
    {
        var balance = 500;
        var deposit = 150;
        var expectedBalance = 650;

        this.Given(_ => AClientHasAnExistingAccountWithABalance(balance))
                .And(_ => ClientRecievesATransferDeposit(deposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheyRecieveADepositOf500_AndTheyRecieveAnotherDepositOf200_ThenTheClientShouldHaveANewAccountBalanceOf700()
    {
        var firstDeposit = 500;
        var secondDeposit = 200;
        var expectedBalance = 700;

        this.Given(_ => AClientOpensANewAccount())
                .And(_ => ClientRecievesATransferDeposit(firstDeposit))
                .And(_ => ClientRecievesATransferDeposit(secondDeposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf3000000001_ThenTheDepositShouldBeRejected_AndTheClientShouldBeToldThatTheyCanNotMakeTheDepositDueToExceedingTheMaximumAccountBalanceOf3000000000()
    {
        var deposit = 3000000001;
        var loggedMessage = $"Warning: You can not make the transfer of £ 3000000001, as Dr. Smith will exceed the maximum account balance on the account!";
        var balance = 0;

        this.Given(_ => AClientOpensANewAccount())
            .When(_ => ClientRecievesATransferDeposit(deposit))
            .Then(_ => DepositShouldBeRejected(loggedMessage))
                .And(_ => ClientShouldHaveAnAccountBalance(balance))
        .BDDfy();
    }

    private void ClientRecievesATransferDeposit(decimal deposit) => Account.TransferDeposit(deposit);

    private new void DepositShouldBeRejected(string message)
        => Account.GetExternalLog().Should().BeEquivalentTo(message);
}