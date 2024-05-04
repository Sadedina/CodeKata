namespace SoftwareCrafters.Tests.Module_7;

public class AccountBalance_Tests : Fixture
{
    [Test]
    public void GivenAClientOpensANewAccount_WhenTheClientViewsTheirBalance_ThenTheClientShouldHaveAnAccountBalanceOf0()
    {
        var expectedBalance = 0;

        this.Given(_ => AClientOpensANewAccount())
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
            .BDDfy();
    }

    [Test]
    public void GivenAClientHasAnExistingAccountWithABalanceOf1000_WhenTheClientViewsTheirBalance_ThenTheClientShouldHaveAnAccountBalanceOf1000()
    {
        var expectedBalance = 1000;

        this.Given(_ => AClientHasAnExistingAccountWithABalance(expectedBalance))
            .Then(_ => ClientShouldHaveAnAccountBalance(expectedBalance))
        .BDDfy();
    }
}