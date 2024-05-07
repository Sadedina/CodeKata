using SoftwareCrafters.Module_8;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

public class Conjured_Tests
{
    private const string Product = "Conjured";

    [Test]
    public void UpdateQuality_ReturnsQualityMinus2()
    {
        var items = CreateItemIntoList(sellIn: 15, quality: 50, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(48, item.Quality);
    }

    [Test]
    public void UpdateQuality_AndSellInLess0_ReturnsQualityMinus4()
    {
        var items = CreateItemIntoList(sellIn: -5, quality: 10, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(6, item.Quality);
    }

    [Test]
    public void UpdateQuality_ReturnsQualityCappedAt0()
    {
        var items = CreateItemIntoList(sellIn: -5, quality: 1, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(0, item.Quality);
    }

    [Test]
    public void UpdateQuality_ReturnsSellInMinus1()
    {
        var items = CreateItemIntoList(sellIn: 5, quality: 30, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(4, item.SellIn);
    }

    [Test]
    public void UpdateQuality_ReturnsSellInAndQuality()
    {
        var items = CreateItemIntoList(sellIn: 10, quality: 48, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(9, item.SellIn);
        Assert.AreEqual(46, item.Quality);
    }

    private static List<Item> CreateItemIntoList(int sellIn, int quality, out Item item)
    {
        item = new Item { Name = Product, SellIn = sellIn, Quality = quality };
        return new() { item };
    }

    private static void CallUpdateQuality(List<Item> items)
    {
        var app = new GildedRose(items);
        app.UpdateQuality();
    }
}