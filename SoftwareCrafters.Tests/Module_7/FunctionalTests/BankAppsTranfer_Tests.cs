using FluentAssertions;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsTranfer_Tests : Fixture
{
    [Test]
    public void GivenAClientOpensANewAccount_WhenTheyRecieveADeposit_ThenTheClientShouldHaveANewAccountBalance()
    {
        var amount = 100;

        var detailsA = CreateAnAcountDetailWithBalance(500);
        var expectedBalanceA = detailsA.Balance - amount;

        var detailsB = CreateAnotherAcountDetailWithBalance();
        var expectedBalanceB = amount;

        this.Given(_ => AClientWithAnAccount(detailsA))
            .When(_ => ClientBRecievesATransferFromClientA(detailsB, amount))
            .Then(_ => ClientShouldHaveAnAccountBalance(detailsA, expectedBalanceA))
                .And(_ => ClientShouldHaveAnAccountBalance(detailsB, expectedBalanceB))
            .BDDfy();
    }

    [Test]
    public void GivenAClientHasAnExistingAccountWithABalanceOf500_WhenTheyRecieveADepositOf150_ThenTheClientShouldHaveANewAccountBalanceOf650()
    {
        var amount = 150;

        var detailsA = CreateAnAcountDetailWithBalance();
        var expectedBalanceA = detailsA.Balance - amount;

        var detailsB = CreateAnotherAcountDetailWithBalance(500);
        var expectedBalanceB = detailsB.Balance + amount;

        this.Given(_ => AClientWithAnAccount(detailsA))
            .When(_ => ClientBRecievesATransferFromClientA(detailsB, amount))
            .Then(_ => ClientShouldHaveAnAccountBalance(detailsA, expectedBalanceA))
                .And(_ => ClientShouldHaveAnAccountBalance(detailsB, expectedBalanceB))
            .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheyRecieveADepositOf500_AndTheyRecieveAnotherDepositOf200_ThenTheClientShouldHaveANewAccountBalanceOf700()
    {
        var firstAmount = 500;
        var secondAmount = 200;

        var detailsA = CreateAnAcountDetailWithBalance();
        var expectedBalanceA = detailsA.Balance - firstAmount - secondAmount;

        var detailsB = CreateAnotherAcountDetailWithBalance(500);
        var expectedBalanceB = detailsB.Balance + firstAmount + secondAmount;

        this.Given(_ => AClientWithAnAccount(detailsA))
            .When(_ => ClientBRecievesATransferFromClientA(detailsB, firstAmount))
                .And(_ => ClientBRecievesATransferFromClientA(detailsB, secondAmount))
            .Then(_ => ClientShouldHaveAnAccountBalance(detailsA, expectedBalanceA))
                .And(_ => ClientShouldHaveAnAccountBalance(detailsB, expectedBalanceB))
            .BDDfy();
    }

    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf3000000001_ThenTheDepositShouldBeRejected_AndTheClientShouldBeToldThatTheyCanNotMakeTheDepositDueToExceedingTheMaximumAccountBalanceOf3000000000()
    {
        var amount = 3000000001;

        var detailsA = CreateAnAcountDetailWithBalance(3000000000);
        var expectedBalanceA = detailsA.Balance;

        var detailsB = CreateAnotherAcountDetailWithBalance(10000);
        var expectedBalanceB = detailsB.Balance;

        var loggedMessage = $"Warning: You can not make the transfer of £ 3000000001, as Mrs Taylor will exceed the maximum account balance on the account!";

        this.Given(_ => AClientWithAnAccount(detailsA))
            .When(_ => ClientBRecievesATransferFromClientA(detailsB, amount))
            .Then(_ => DepositShouldBeRejected(detailsA, loggedMessage))
            .Then(_ => ClientShouldHaveAnAccountBalance(detailsA, expectedBalanceA))
                .And(_ => ClientLogShouldBeEmpty(detailsB))
                .And(_ => ClientShouldHaveAnAccountBalance(detailsB, expectedBalanceB))
            .BDDfy();
    }

    internal static AccountDetails CreateAnotherAcountDetailWithBalance(decimal amount = 0)
    {
        var client = new Client("Mrs", "Karen", "Taylor"); ;

        return new(client) { Balance = amount };
    }

    private void ClientBRecievesATransferFromClientA(AccountDetails details, decimal amount)
        => bankApps.TransferIntoAccount(details, amount);

    private static void ClientShouldHaveAnAccountBalance(AccountDetails details, decimal amount)
        => details.Balance.Should().Be(amount);

    private static void ClientLogShouldBeEmpty(AccountDetails details)
        => details.Logs.Should().BeNullOrEmpty();
}