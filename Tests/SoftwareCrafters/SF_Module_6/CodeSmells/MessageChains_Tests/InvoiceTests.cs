using NUnit.Framework;
using SoftwareCrafters.SF_Module_6.CodeSmells.MessageChains;

namespace Tests.SoftwareCrafters.SF_Module_6.CodeSmells.MessageChains_Tests;

[TestFixture]
public class InvoiceTests
{
    [Test]
    public void ShippingShouldBeAddedIfAddressIsNotInEurope()
    {
        var address = new Address(new Country(false));
        var customer = new Customer(address);

        var invoice = new Invoice(customer);
        invoice.AddItem(new InvoiceItem("Product X", 1, 100));

        Assert.That(100 + Invoice.SHIPPING_COST_OUTSIDE_EU, Is.EqualTo(invoice.TotalPrice));
    }
}