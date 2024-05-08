namespace SoftwareCrafters.Module_8.Models;

public class AgedBrie : IProduct
{
    public string Name { get; set; } = "Aged Brie";
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateItemQuality()
    {
        Quality++;
        SellIn--;

        if (SellIn < 0)
            Quality++;

        if (Quality > 50)
            Quality = 50;
    }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}