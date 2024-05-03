using SoftwareCrafters.Module_6.CodeSmells.DataClumps;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.DataClumps_Tests;

#region Original
//[TestFixture]
//public class CustomerTests
//{
//    [Test]
//    public void CustomerAddressSummaryIncludesHouseStreetCityPostCodeAndCountry()
//    {
//        var customer = new Customer("Dr", "Joseph", "Bloggs", "43", "Rankin Road", "London", "SW23 9YY", "United Kingdom");

//        Assert.That("43, Rankin Road, London, SW23 9YY, United Kingdom", Is.EqualTo(customer.AddressSummary));
//    }
//}
#endregion

[TestFixture]
public class CustomerTests
{
    [Test]
    public void CustomerAddressSummaryIncludesHouseStreetCityPostCodeAndCountry()
    {
        var address = new Address
        {
            House = "43",
            Street = "Rankin Road",
            City = "London",
            PostCode = "SW23 9YY",
            Country = "United Kingdom"
        };

        var customer = new Customer
        {
            Title = "Dr",
            FirstName = "Joseph",
            LastName = "Bloggs",
            Address = address
        };

        Assert.That("43, Rankin Road, London, SW23 9YY, United Kingdom", Is.EqualTo(customer.Address.Summary));
    }
}