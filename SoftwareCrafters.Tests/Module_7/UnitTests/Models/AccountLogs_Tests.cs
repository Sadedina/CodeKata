using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.UnitTests.Models;

public class AccountDetails_Tests
{
    [Test]
    public void AddInternalLog_GivenAMessage_AddsToInternalLog()
    {
        var message = "Test message";
        var client = new Client("Mr", "John", "Smith");
        var logs = new AccountDetails(client);

        logs.AddIntoLog(message);

        Assert.Contains(message, logs.Logs);
    }
}