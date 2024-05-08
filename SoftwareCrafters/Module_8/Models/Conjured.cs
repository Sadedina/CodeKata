namespace SoftwareCrafters.Module_8.Models;

public class Conjured : IProduct
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateItemQuality()
    {
        Quality -= 2;
        SellIn--;

        if (SellIn < 0)
            Quality -= 2;

        if (Quality < 0)
            Quality = 0;
    }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}