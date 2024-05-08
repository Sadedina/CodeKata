using SoftwareCrafters.Module_8.Models;

namespace SoftwareCrafters.Module_8;

public class Shop
{
    private readonly IList<IProduct> items;

    public Shop(IList<IProduct> Items) => items = Items;

    public void UpdateQuality()
        => items.ToList().ForEach(item => item.UpdateItemQuality());
}