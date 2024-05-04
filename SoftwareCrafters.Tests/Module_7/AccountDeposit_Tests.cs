using SoftwareCrafters.Module_7;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountDeposit_Tests : Fixture
{
    [TestCase(1000)]
    [TestCase(2000)]
    [TestCase(0.50)]
    [TestCase(2150000000.00)]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADeposit_ThenTheClientShouldHaveANewAccountBalance(
        decimal amount)
    {
        var deposit = amount;

        this.Given(_ => AClientOpensANewAccount())
            .When(_ => ClientMakesADeposit(deposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(deposit))
            .BDDfy();
    }

    [Test]
    public void GivenAClientHasAnExistingAccountWithABalanceOf500_WhenTheClientMakesADepositOf150_ThenTheClientShouldHaveANewAccountBalanceOf650()
    {
        var balance = 500;
        var deposit = 150;
        var expectedBalance = 650;

        this.Given(_ => AClientHasAnExistingAccountWithABalance(balance))
                .And(_ => ClientMakesADeposit(deposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf500_AndTheClientMakesADepositOf200_ThenTheClientShouldHaveANewAccountBalanceOf700()
    {
        var firstDeposit = 500;
        var secondDeposit = 200;
        var expectedBalance = 700;

        this.Given(_ => AClientOpensANewAccount())
                .And(_ => ClientMakesADeposit(firstDeposit))
                .And(_ => ClientMakesADeposit(secondDeposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf3000000001_ThenTheDepositShouldBeRejected_AndTheClientShouldBeToldThatTheyCanNotMakeTheDepositDueToExceedingTheMaximumAccountBalanceOf3000000000()
    {
        var deposit = 3000000001;
        var loggedMessage = $"Warning: You can not make the deposit of £ 3000000001, due to exceeding the maximum account balance of £ 3,000,000,000!";
        var balance = 0;

        this.Given(_ => AClientOpensANewAccount())
            .When(_ => ClientMakesADeposit(deposit))
            .Then(_ => DepositShouldBeRejected(loggedMessage))
                .And(_ => ClientShouldHaveAnAccountBalance(balance))
        .BDDfy();
    }

    private void ClientMakesADeposit(decimal expectedDeposit) => Account.Deposit(expectedDeposit);
}