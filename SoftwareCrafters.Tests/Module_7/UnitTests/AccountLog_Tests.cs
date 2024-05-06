using SoftwareCrafters.Module_7;
using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7;

public class AccountLog_Tests
{
    [Test]
    public void AddLog_AddsToLog()
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client);
        var message = "Warning!";

        var account = new Account(details);
        account.AddLog(message);

        Assert.Contains(message, details.Logs);
    }

    [Test]
    public void GetLog_ReturnsLog()
    {
        var client = new Client("Dr.", "Jack", "Smith");
        var details = new AccountDetails(client);
        var message = "Warning!";

        var account = new Account(details);
        account.AddLog(message);
        var logs = account.GetLog();

        Assert.Contains(message, logs);
    }
}