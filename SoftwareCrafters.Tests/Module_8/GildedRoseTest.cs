using SoftwareCrafters.Module_8;

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

namespace SoftwareCrafters.Tests.Module_8;

[TestFixture]
public class GildedRoseTest
{
    [Test]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.That("fixme", Is.EqualTo(Items[0].Name));
    }
}