using SoftwareCrafters.Module_7.Models;

namespace SoftwareCrafters.Tests.Module_7.UnitTests.Models;

public class Client_Tests
{
    [Test]
    public void ToString_GivenAClient_ReturnsExpectedString()
    {
        var client = new Client("Mr", "John", "Smith");

        var expected = "Mr Smith";

        Assert.AreEqual(expected, client.ToString());
    }
}