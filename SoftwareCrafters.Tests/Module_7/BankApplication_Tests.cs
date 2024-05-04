using FluentAssertions;
using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class BankApplication_Tests : Fixture
{
    [Test]
    public void GivenClientAHasAnAccountWithABalanceOf1000_AndClientBHasABalanceOf5000_WhenClientATransfers500ToClientB_ThenClientAShouldHaveABalanceOf500_AndClientBShouldHaveABalanceOf5500()
    {
        var clientA = new Client("Mr", "Taylor", "Brown");
        var balanceA = 1000;
        var accountA = CreateExistingClientAccountWithABalance(clientA, balanceA);

        var clientB = new Client("Mrs", "Rebecca", "Brown");
        var balanceB = 5000;
        var accountB = CreateExistingClientAccountWithABalance(clientB, balanceB);

        var transfer = 500;
        var finalBalanceA = 500;
        var finalBalanceB = 5500;

        this.Given(_ => ClientATransfersToClientB(accountA, accountB, transfer))
            .Then(_ => ClientShouldHaveAnAccountBalance(accountA, finalBalanceA))
                .And(_ => ClientShouldHaveAnAccountBalance(accountB, finalBalanceB))
        .BDDfy();
    }

    [Test]
    public void GivenClientAHasAnAccountWithABalanceOf1000_AndClientBHasAnAccountWithABalanceOf2999999999_WhenClientATransfers2ToClientB_ThenTheTransferShouldBeRejected_AndClientAShouldBeToldThatClientBCanNotAcceptTheTransactionBecauseOfHowRichTheyAre()
    {
        var clientA = new Client("Mr", "Taylor", "Brown");
        var balanceA = 1000;
        var accountA = CreateExistingClientAccountWithABalance(clientA, balanceA);

        var clientB = new Client("Mrs", "Rebecca", "Brown");
        var balanceB = 2999999999;
        var accountB = CreateExistingClientAccountWithABalance(clientB, balanceB);

        var transfer = 10;
        var loggedMessage = $"Warning: You can not make the transfer of £ 10, as Mrs Brown will exceed the maximum account balance on the account!";


        this.Given(_ => ClientATransfersToClientB(accountA, accountB, transfer))
            .Then(_ => TransferDepositShouldBeRejected(accountA, loggedMessage))
                .And(_ => DepositShouldNotBeLoggedIn(accountB))
                .And(_ => ClientShouldHaveAnAccountBalance(accountA, balanceA))
                .And(_ => ClientShouldHaveAnAccountBalance(accountB, balanceB))
        .BDDfy();
    }

    private Account CreateExistingClientAccountWithABalance(Client client, decimal expectedBalance)
    {
        Account = new Account(client);
        Account.Deposit(expectedBalance);
        return Account;
    }
    private static void ClientATransfersToClientB(Account accountA, Account accountB, decimal transfer)
    {
        var app = new BankApplication();
        app.Transfer(accountA, accountB, transfer);
    }

    private static void ClientShouldHaveAnAccountBalance(Account account, decimal balance)
        => account.GetBalance().Should().Be(balance);

    private static void TransferDepositShouldBeRejected(Account account, string message)
        => account.Log.Should().ContainEquivalentOf(message);


    private static void DepositShouldNotBeLoggedIn(Account account)
        => account.Log.Should().BeEmpty();
}