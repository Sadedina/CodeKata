namespace SoftwareCrafters.Tests.Module_7.FunctionalTests;

public class BankAppsBalance_Tests : Fixture
{
    [TestCase(0)]
    [TestCase(1000)]
    public void GivenAClientWithAnAccount_WhenTheClientViewsTheirBalance_ThenTheClientShouldHaveAnAccountBalance(
        decimal amount)
    {
        var details = CreateAnAcountDetailWithBalance(amount);
        var expectedBalance = GetBalance(details);

        this.Given(_ => AClientWithAnAccount(details))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }
}