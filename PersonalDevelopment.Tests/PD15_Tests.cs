namespace PersonalDevelopment.Tests;

public class PD15_Tests
{
    [Test]
    public void CreateMethodName_GivenInput_ReturnsOutput()
    {
        const string givenWhenThen = "GIVEN a client opens a new account\r\nWHEN the client makes a withdrawal of 1001\r\nTHEN the withdrawal should be rejected\r\nAND the client should be told they can not exceed overdraft of 1000";

        var methodName = PD15.CreateMethodName(givenWhenThen);

        Assert.AreNotEqual("", methodName);
    }

    [TestCaseSource(nameof(TestScript))]
    public void CreateMethodName_WhenGivenWhenThenIsValid_ReturnsMethodName(
        List<string> givenWhenThen,
        string expectedMethodName)
    {
        var methodName = PD15.CreateMethodName(givenWhenThen);

        Assert.AreEqual(expectedMethodName, methodName);
    }

    public static IEnumerable<object[]> TestScript()
    {
        const string expectedNameOne = "GivenAClientOpensANewAccount_WhenTheClientViewsTheirBalance_ThenTheClientShouldHaveAnAccountBalanceOf0";
        var listNameOne = new List<string>
        {
            "GIVEN a client opens a new account",
            "WHEN the client views their balance",
            "THEN the client should have an account balance of 0"
        };

        const string expectedNameTwo = "GivenAClientHasAnExistingAccountWithABalanceOf1000_WhenTheClientViewsTheirBalance_ThenTheClientShouldHaveAnAccountBalanceOf1000";
        var listNameTwo = new List<string>
        {
            "GIVEN a client has an existing account with a balance of 1000",
            "WHEN the client views their balance",
            "THEN the client should have an account balance of 1000"
        };

        const string expectedNameThree = "GivenAClientOpensANewAccount_WhenTheClientMakesADepositOf500_AndTheClientMakesADepositOf200_ThenTheClientShouldHaveANewAccountBalanceOf700";
        var listNameThree = new List<string>
        {
            "GIVEN a client opens a new account",
            "WHEN the client makes a deposit of 500",
            "AND the client makes a deposit of 200",
            "THEN the client should have a new account balance of 700"
        };

        return new List<object[]>
        {
            new object[] { listNameOne, expectedNameOne },
            new object[] { listNameTwo, expectedNameTwo },
            new object[] { listNameThree, expectedNameThree }
        };
    }
}