using SoftwareCrafters.Module_8;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

public class Sulfuras_Tests
{
    private const string Product = "Sulfuras, Hand of Ragnaros";

    [TestCase(5, 0)]
    [TestCase(5, 30)]
    [TestCase(5, 60)]
    [TestCase(-5, 30)]
    public void UpdateQuality_ReturnsSameSellInAndQuality(int sellIn, int quality)
    {
        var item = new Item { Name = Product, SellIn = sellIn, Quality = quality };
        var items = new List<Item> { item };

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.AreEqual(sellIn, item.SellIn);
        Assert.AreEqual(quality, item.Quality);
    }
}