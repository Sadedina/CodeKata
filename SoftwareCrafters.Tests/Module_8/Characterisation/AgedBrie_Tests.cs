using SoftwareCrafters.Module_8;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

public class AgedBrie_Tests
{
    private const string Product = "Aged Brie";

    [Test]
    public void UpdateQuality_GivenQualityLess50_ReturnsQualityPlus1()
    {
        var items = CreateItemIntoList(sellIn: 11, quality: 30, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(31, item.Quality);
    }

    [Test]
    public void UpdateQuality_AndSellInLess0_ReturnsQualityPlus2()
    {
        var items = CreateItemIntoList(sellIn: -1, quality: 30, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(32, item.Quality);
    }

    [Test]
    public void UpdateQuality_ReturnsQualityCappedAt50()
    {
        var items = CreateItemIntoList(sellIn: -5, quality: 49, item: out var item);
        CallUpdateQuality(items);

        Assert.AreEqual(50, item.Quality);
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
        Assert.AreEqual(49, item.Quality);
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