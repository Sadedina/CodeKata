using NUnit.Framework;
using SoftwareCrafters.SF_Module_6.CodeSmells.DataClumps;

namespace Tests.SoftwareCrafters.SF_Module_6.CodeSmells.DataClumps_Tests;

[TestFixture]
public class CustomerTests
{
    [Test]
    public void CustomerAddressSummaryIncludesHouseStreetCityPostCodeAndCountry()
    {
        var customer = new Customer("Dr", "Joseph", "Bloggs", "43", "Rankin Road", "London", "SW23 9YY", "United Kingdom");

        Assert.That("43, Rankin Road, London, SW23 9YY, United Kingdom", Is.EqualTo(customer.AddressSummary));
    }
}