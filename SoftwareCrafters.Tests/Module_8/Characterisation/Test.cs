using SoftwareCrafters.Module_8;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

public class Test1
{

    [Test]
    public void UpdateQuality_GivenAProduct_ReturnsNameOfProduct()
    {
        var name = "Foo";
        var item = new Item { Name = name, SellIn = 0, Quality = 0 };
        var items = new List<Item> { item };

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.That(name, Is.EqualTo(items[0].Name));
    }
}