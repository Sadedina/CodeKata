namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsStatement_Tests : Fixture
{
    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientMakesTransactions_AndPrintsStatements_ReturnsAllTransactions()
    {
        var details = CreateAnAcountDetailWithBalance();
        var transactionOne = 1000;
        var transactionDateOne = new DateTime(2012, 01, 10);

        var transactionTwo = 2000;
        var transactionDateTwo = new DateTime(2012, 01, 13);

        var transactionThree = 500;
        var transactionDateThree = new DateTime(2012, 01, 14);

        var expectedStatement = new List<string[]>
        {
            new string[] {"14/01/2012", "0.00", "500.00", "2500.00" },
            new string[] {"13/01/2012", "2000.00", "0.00", "3000.00" },
            new string[] {"10/01/2012", "1000.00", "0.00", "1000.00" }
        };

        this.Given(_ => AClientWithAnAccount(details))
                .And(_ => ClientMakesADeposit(transactionOne, transactionDateOne))
                .And(_ => ClientMakesADeposit(transactionTwo, transactionDateTwo))
                .And(_ => ClientMakesAWithdrawal(transactionThree, transactionDateThree))
            .Then(_ => PrintsStatementShouldBeSuccesfull(expectedStatement))
            .BDDfy();
    }

    private void ClientMakesADeposit(decimal amount, DateTime date) => bankApps.DepositIntoAccount(amount, date);

    private void ClientMakesAWithdrawal(decimal amount, DateTime date) => bankApps.WithdrawalFromAccount(amount, date);

    private void PrintsStatementShouldBeSuccesfull(List<string[]> expectedStatements)
    {
        var statements = bankApps.GetStatement();

        for (int i = 0; i < statements.Count; i++)
        {
            statements[i].Should().BeEquivalentTo(expectedStatements[i]);
        }
    }
}