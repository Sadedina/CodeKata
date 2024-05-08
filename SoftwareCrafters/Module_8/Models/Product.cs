namespace SoftwareCrafters.Module_8.Models;

public class Product : IProduct
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public virtual void UpdateItemQuality()
    {
        Quality--;
        SellIn--;

        if (SellIn < 0)
            Quality--;

        if (Quality < 0)
            Quality = 0;
    }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}