using NUnit.Framework;
using SoftwareCrafters.Module_6.CodeSmells.LongParametersLists;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.LongParametersLists_Tests;

[TestFixture]
public class CustomerTests
{
    [Test]
    public void CustomerSummaryIncludesFullNameWithTitleAndCityPostCodeAndCountry()
    {
        var customer = new Customer();
        customer.FirstName = "Jason";
        customer.LastName = "Gorman";
        customer.Title = "Mr";
        var address = new Address();
        address.City = "London";
        address.Postcode = "SW23 9YY";
        address.Country = "United Kingdom";
        customer.Address = address;
        Assert.That("Mr Jason Gorman, London, SW23 9YY, United Kingdom", Is.EqualTo(customer.Summary));
    }
}