using SoftwareCrafters.Module_6.CodeSmells.DivergentChange;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.DivergentChange_Tests;

[TestFixture]
public class OnDemandAgentServiceTests
{
    [Test]
    public void StartingANewVMFillHostAnIPOnOnDEmandAgent()
    {
        var service = new OnDemandAgentService();
        var log = new List<string>();
        service.Log = log;
        service.Password = "passw0rd";
        service.Username = "admin";

        var agent = service.StartNewOnDemandMachine();

        Assert.That(agent.Host, Is.Not.Empty);
        Assert.That(agent.Ip, Is.Not.Empty);
    }

    [Test]
    public void ThrowsNotUthorizedIfInvalidCredentials()
    {
        var service = new OnDemandAgentService();
        var log = new List<string>();
        service.Log = log;
        service.Password = string.Empty;
        service.Username = string.Empty;

        Assert.Throws<UnauthorizedAccessException>(() => service.StartNewOnDemandMachine());
    }
}