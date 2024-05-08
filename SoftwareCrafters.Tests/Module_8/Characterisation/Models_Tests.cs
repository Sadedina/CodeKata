using SoftwareCrafters.Module_8;
using SoftwareCrafters.Module_8.Models;

namespace SoftwareCrafters.Tests.Module_8.Characterisation;

public class Models_Tests
{
    [TestCase(11, 10, 50, 49)]
    [TestCase(-5, -6, 10, 8)]
    [TestCase(-10, -11, 1, 0)]
    public void UpdateQuality_GivenProduct_ReturnsExpected(
        int sellIn,
        int expectedSellIn,
        int quality,
        int expectedQuality)
    {
        var item = new Product { Name = "", SellIn = sellIn, Quality = quality };
        var items = new List<IProduct>() { item };

        var app = new Shop(items);
        app.UpdateQuality();

        Assert.AreEqual(expectedSellIn, item.SellIn);
        Assert.AreEqual(expectedQuality, item.Quality);
    }

    [TestCase(11, 10, 30, 31)]
    [TestCase(-1, -2, 30, 32)]
    [TestCase(-5, -6, 49, 50)]
    public void UpdateQuality_GivenAgedBrie_ReturnsExpected(
        int sellIn,
        int expectedSellIn,
        int quality,
        int expectedQuality)
    {
        var item = new AgedBrie { SellIn = sellIn, Quality = quality };
        var items = new List<IProduct>() { item };

        var app = new Shop(items);
        app.UpdateQuality();

        Assert.AreEqual(expectedSellIn, item.SellIn);
        Assert.AreEqual(expectedQuality, item.Quality);
    }

    [TestCase(11, 10, 30, 31)]
    [TestCase(10, 9, 40, 42)]
    [TestCase(5, 4, 15, 18)]
    [TestCase(1, 0, 49, 50)]
    [TestCase(-1, -2, 25, 0)]
    public void UpdateQuality_GivenBackstagePasses_ReturnsExpected(
       int sellIn,
       int expectedSellIn,
       int quality,
       int expectedQuality)
    {
        var item = new BackstagePasses { SellIn = sellIn, Quality = quality };
        var items = new List<IProduct>() { item };

        var app = new Shop(items);
        app.UpdateQuality();

        Assert.AreEqual(expectedSellIn, item.SellIn);
        Assert.AreEqual(expectedQuality, item.Quality);
    }

    [TestCase(11, 11, 30, 30)]
    [TestCase(-1, -1, 50, 50)]
    public void UpdateQuality_GivenSulfuras_ReturnsExpected(
       int sellIn,
       int expectedSellIn,
       int quality,
       int expectedQuality)
    {
        var item = new Sulfuras { SellIn = sellIn, Quality = quality };
        var items = new List<IProduct>() { item };

        var app = new Shop(items);
        app.UpdateQuality();

        Assert.AreEqual(expectedSellIn, item.SellIn);
        Assert.AreEqual(expectedQuality, item.Quality);
    }

    [TestCase(11, 10, 30, 28)]
    [TestCase(-5, -6, 10, 6)]
    [TestCase(-1, -2, 1, 0)]
    public void UpdateQuality_GivenConjured_ReturnsExpected(
       int sellIn,
       int expectedSellIn,
       int quality,
       int expectedQuality)
    {
        var item = new Conjured { Name = "Conjured", SellIn = sellIn, Quality = quality };
        var items = new List<IProduct>() { item };

        var app = new Shop(items);
        app.UpdateQuality();

        Assert.AreEqual(expectedSellIn, item.SellIn);
        Assert.AreEqual(expectedQuality, item.Quality);
    }
}