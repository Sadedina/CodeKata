﻿using SoftwareCrafters.Module_6.CodeSmells.MessageChains;

namespace Tests.SoftwareCrafters.Tests.Module_6.CodeSmells.MessageChains_Tests;

#region Original
//[TestFixture]
//public class InvoiceTests
//{
//    [Test]
//    public void ShippingShouldBeAddedIfAddressIsNotInEurope()
//    {
//        var address = new Address(new Country(false));
//        var customer = new Customer(address);

//        var invoice = new Invoice(customer);
//        invoice.AddItem(new InvoiceItem("Product X", 1, 100));

//        Assert.That(100 + Invoice.SHIPPING_COST_OUTSIDE_EU, Is.EqualTo(invoice.TotalPrice));
//    }
//}
#endregion

[TestFixture]
public class InvoiceTests
{
    [Test]
    public void ShippingShouldBeAddedIfAddressIsNotInEurope()
    {
        var isInEurope = false;

        var invoice = new Invoice(isInEurope);
        invoice.AddItem(new InvoiceItem("Product X", 1, 100));

        Assert.That(100 + Invoice.SHIPPING_COST_OUTSIDE_EU, Is.EqualTo(invoice.TotalPrice));
    }
}