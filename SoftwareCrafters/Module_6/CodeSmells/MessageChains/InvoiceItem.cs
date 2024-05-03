namespace SoftwareCrafters.Module_6.CodeSmells.MessageChains;

#region Original
//public class InvoiceItem
//{
//    private readonly int quantity;

//    private readonly double unitPrice;

//    private string itemName;

//    public InvoiceItem(string itemName, int quantity, double unitPrice)
//    {
//        this.itemName = itemName;
//        this.quantity = quantity;
//        this.unitPrice = unitPrice;
//    }

//    public double Subtotal
//    {
//        get
//        {
//            return unitPrice * quantity;
//        }
//    }
//}
#endregion

public class InvoiceItem
{
    private readonly int quantity;
    private readonly double unitPrice;
    private string itemName;

    public InvoiceItem(string itemName, int quantity, double unitPrice)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
    }

    public double Subtotal => unitPrice * quantity;
}