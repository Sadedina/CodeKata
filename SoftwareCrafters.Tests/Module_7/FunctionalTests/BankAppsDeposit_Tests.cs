namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsDeposit_Tests : Fixture
{
    [TestCase(1000)]
    [TestCase(2000)]
    [TestCase(0.50)]
    [TestCase(2150000000.00)]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADeposit_ThenTheClientShouldHaveANewAccountBalance(
        decimal amount)
    {
        var details = CreateAnAcountDetailWithBalance();
        var expectedBalance = amount;

        this.Given(_ => AClientWithAnAccount(details))
            .When(_ => ClientMakesADeposit(amount))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
            .BDDfy();
    }

    [Test]
    public void GivenAClientHasAnExistingAccountWithABalanceOf500_WhenTheClientMakesADepositOf150_ThenTheClientShouldHaveANewAccountBalanceOf650()
    {
        var details = CreateAnAcountDetailWithBalance(500);
        var deposit = 150;
        var expectedBalance = 650;

        this.Given(_ => AClientWithAnAccount(details))
                .And(_ => ClientMakesADeposit(deposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf500_AndTheClientMakesADepositOf200_ThenTheClientShouldHaveANewAccountBalanceOf700()
    {
        var details = CreateAnAcountDetailWithBalance(500);
        var firstDeposit = 500;
        var secondDeposit = 200;
        var expectedBalance = 700;

        this.Given(_ => AClientWithAnAccount(details))
                .And(_ => ClientMakesADeposit(firstDeposit))
                .And(_ => ClientMakesADeposit(secondDeposit))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf3000000001_ThenTheDepositShouldBeRejected_AndTheClientShouldBeToldThatTheyCanNotMakeTheDepositDueToExceedingTheMaximumAccountBalanceOf3000000000()
    {
        var details = CreateAnAcountDetailWithBalance(500);
        var deposit = 3000000001;
        var loggedMessage = $"Warning: You can not make the deposit of £ 3000000001, due to exceeding the maximum account balance of £ 3,000,000,000!";
        var balance = 0;

        this.Given(_ => AClientWithAnAccount(details))
            .When(_ => ClientMakesADeposit(deposit))
            .Then(_ => DepositShouldBeRejected(details, loggedMessage))
                .And(_ => ClientShouldHaveAnAccountBalance(balance))
        .BDDfy();
    }

    private void ClientMakesADeposit(decimal amount) => bankApps.DepositIntoAccount(amount);
}