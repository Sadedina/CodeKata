using SoftwareCrafters.Module_8;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

#region Original
//namespace SoftwareCrafters.Tests.Module_8
//{
//    [TestFixture]
//    public class GildedRoseTest
//    {
//        [Test]
//        public void foo()
//        {
//            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
//            GildedRose app = new GildedRose(Items);
//            app.UpdateQuality();
//            Assert.That("fixme", Is.EqualTo(Items[0].Name));
//        }
//    }
//}
#endregion
public class Test
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