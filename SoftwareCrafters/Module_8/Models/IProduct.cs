namespace SoftwareCrafters.Module_8.Models;

public interface IProduct
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public void UpdateItemQuality();
    public string ToString();
}