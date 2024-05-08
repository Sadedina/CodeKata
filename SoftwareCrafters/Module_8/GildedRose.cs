namespace SoftwareCrafters.Module_8;

#region Original
//public class GildedRose
//{
//    IList<Item> Items;
//    public GildedRose(IList<Item> Items)
//    {
//        this.Items = Items;
//    }

//    public void UpdateQuality()
//    {
//        for (var i = 0; i < Items.Count; i++)
//        {
//            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
//            {
//                if (Items[i].Quality > 0)
//                {
//                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//                    {
//                        Items[i].Quality = Items[i].Quality - 1;
//                    }
//                }
//            }
//            else
//            {
//                if (Items[i].Quality < 50)
//                {
//                    Items[i].Quality = Items[i].Quality + 1;

//                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
//                    {
//                        if (Items[i].SellIn < 11)
//                        {
//                            if (Items[i].Quality < 50)
//                            {
//                                Items[i].Quality = Items[i].Quality + 1;
//                            }
//                        }

//                        if (Items[i].SellIn < 6)
//                        {
//                            if (Items[i].Quality < 50)
//                            {
//                                Items[i].Quality = Items[i].Quality + 1;
//                            }
//                        }
//                    }
//                }
//            }

//            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//            {
//                Items[i].SellIn = Items[i].SellIn - 1;
//            }

//            if (Items[i].SellIn < 0)
//            {
//                if (Items[i].Name != "Aged Brie")
//                {
//                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
//                    {
//                        if (Items[i].Quality > 0)
//                        {
//                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//                            {
//                                Items[i].Quality = Items[i].Quality - 1;
//                            }
//                        }
//                    }
//                    else
//                    {
//                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
//                    }
//                }
//                else
//                {
//                    if (Items[i].Quality < 50)
//                    {
//                        Items[i].Quality = Items[i].Quality + 1;
//                    }
//                }
//            }
//        }
//    }
//}
#endregion

public class GildedRose
{
    private readonly IList<Item> items;

    public GildedRose(IList<Item> Items) => items = Items;

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePasses(item);
                continue;
            }

            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
                continue;
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
                continue;

            if (item.Name.StartsWith("Conjured"))
            {
                UpdateConjured(item);
                continue;
            }

            UpdateProduct(item);
        }
    }

    private static void UpdateBackstagePasses(Item item)
    {
        item.Quality++;
        item.SellIn--;

        if (item.SellIn < 10)
            item.Quality++;

        if (item.SellIn < 5)
            item.Quality++;

        if (item.Quality > 50)
            item.Quality = 50;

        if (item.SellIn < 0)
            item.Quality = 0;
    }
    private static void UpdateAgedBrie(Item item)
    {
        item.Quality++;
        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality++;

        if (item.Quality > 50)
            item.Quality = 50;
    }

    private static void UpdateConjured(Item item)
    {
        item.Quality -= 2;
        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality -= 2;

        if (item.Quality < 0)
            item.Quality = 0;
    }

    private static void UpdateProduct(Item item)
    {
        item.Quality--;
        item.SellIn--;

        if (item.SellIn < 0)
            item.Quality--;

        if (item.Quality < 0)
            item.Quality = 0;
    }
}