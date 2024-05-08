namespace SoftwareCrafters.Module_8;

#region Original
//public class Item
//{
//    public string Name { get; set; }
//    public int SellIn { get; set; }
//    public int Quality { get; set; }

//    public override string ToString()
//    {
//        return Name + ", " + SellIn + ", " + Quality;
//    }
//}
#endregion

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public override string ToString() => Name + ", " + SellIn + ", " + Quality;
}