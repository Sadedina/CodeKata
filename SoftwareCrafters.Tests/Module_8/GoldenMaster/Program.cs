using SoftwareCrafters.Module_8;
using SoftwareCrafters.Module_8.Models;

namespace SoftwareCrafters.Tests.Module_8.GoldenMaster;

#region Original
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Console.WriteLine("OMGHAI!");

//        IList<Item> Items = new List<Item>{
//            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
//            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
//            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
//            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
//            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 15,
//                Quality = 20
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 10,
//                Quality = 49
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 5,
//                Quality = 49
//            },
//            // this conjured item does not work properly yet
//            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
//        };

//        var app = new GildedRose(Items);


//        for (var i = 0; i < 31; i++)
//        {
//            Console.WriteLine("-------- day " + i + " --------");
//            Console.WriteLine("name, sellIn, quality");
//            for (var j = 0; j < Items.Count; j++)
//            {
//                Console.WriteLine(Items[j]);
//            }
//            Console.WriteLine("");
//            app.UpdateQuality();
//        }
//    }
//}
#endregion
#region Attempt1
//public class Program
//{
//    public static void Print()
//    {
//        Console.WriteLine("OMGHAI!");

//        IList<Item> Items = new List<Item>{
//            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
//            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
//            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
//            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
//            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 15,
//                Quality = 20
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 10,
//                Quality = 49
//            },
//            new Item
//            {
//                Name = "Backstage passes to a TAFKAL80ETC concert",
//                SellIn = 5,
//                Quality = 49
//            },
//            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
//            new Item {Name = "Conjured Mana Cake", SellIn = 7, Quality = 21}
//        };

//        var app = new GildedRose(Items);

//        for (var i = 0; i < 31; i++)
//        {
//            Console.WriteLine("-------- day " + i + " --------");
//            Console.WriteLine("name, sellIn, quality");
//            for (var j = 0; j < Items.Count; j++)
//            {
//                Console.WriteLine(Items[j]);
//            }
//            Console.WriteLine("");
//            app.UpdateQuality();
//        }
//    }
//}
#endregion

public class Program
{
    public static void Print()
    {
        Console.WriteLine("OMGHAI!");

        var items = CreateProductList();
        var app = new Shop(items);

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");

            items.ForEach(item => Console.WriteLine(item));

            Console.WriteLine("");
            app.UpdateQuality();
        }
    }

    private static List<IProduct> CreateProductList()
    {
        return new()
        {
            new Product {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new AgedBrie {SellIn = 2, Quality = 0},
            new Product {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Sulfuras {SellIn = 0, Quality = 80},
            new Sulfuras {SellIn = -1, Quality = 80},
            new BackstagePasses {SellIn = 15, Quality = 20},
            new BackstagePasses {SellIn = 10, Quality = 49},
            new BackstagePasses {SellIn = 5, Quality = 49},
            new Conjured {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
            new Conjured {Name = "Conjured Mana Cake", SellIn = 7, Quality = 21}
        };
    }
}