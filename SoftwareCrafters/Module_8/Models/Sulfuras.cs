namespace SoftwareCrafters.Module_8.Models;

public class Sulfuras : IProduct
{
    public string Name { get; set; } = "Sulfuras, Hand of Ragnaros";
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateItemQuality()
    {
    }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}