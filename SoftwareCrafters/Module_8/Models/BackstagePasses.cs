namespace SoftwareCrafters.Module_8.Models;

public class BackstagePasses : IProduct
{
    public string Name { get; set; } = "Backstage passes to a TAFKAL80ETC concert";
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateItemQuality()
    {
        Quality++;
        SellIn--;

        if (SellIn < 10)
            Quality++;

        if (SellIn < 5)
            Quality++;

        if (Quality > 50)
            Quality = 50;

        if (SellIn < 0)
            Quality = 0;
    }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}