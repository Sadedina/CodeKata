namespace SoftwareCrafters.Module_6.CodeSmells.DuplicateCode;

#region Original
//public class TechnicalDebt
//{
//    private readonly IList<Issue> transactions = new List<Issue>();

//    public float Balance { get; private set; }

//    public Issue LastTransaction
//    {
//        get
//        {
//            return transactions[(transactions.Count - 1)];
//        }
//    }

//    public string LastTransactionDate { get; private set; }

//    public void Register(float effortManHours, string description)
//    {
//        float effortManHours1 = -effortManHours;
//        this.Balance -= effortManHours1;
//        transactions.Add(new Issue(-effortManHours1, description));
//        var now = DateTime.Now;
//        this.LastTransactionDate = now.Date + "/" + now.Month + "/" + now.Year;
//    }

//    public void Fix(float effortManHours, string description)
//    {
//        this.Balance -= effortManHours;
//        transactions.Add(new Issue(-effortManHours, description));
//        var now = DateTime.Now;
//        this.LastTransactionDate = now.Date + "/" + now.Month + "/" + now.Year;
//    }
//}
#endregion

public class TechnicalDebt
{
    private readonly IList<Issue> transactions = new List<Issue>();

    public float Balance { get; private set; }
    public string LastTransactionDate { get; private set; }
    public Issue LastTransaction => transactions[transactions.Count - 1];

    public void Register(float effortManHours, string description)
    {
        Balance += effortManHours;
        PerformTransactions(effortManHours, description);
    }

    public void Fix(float effortManHours, string description)
    {
        Balance -= effortManHours;
        PerformTransactions(-effortManHours, description);
    }

    private void PerformTransactions(float effortManHours, string description)
    {
        transactions.Add(new Issue(effortManHours, description));
        var now = DateTime.Now;
        LastTransactionDate = now.Date + "/" + now.Month + "/" + now.Year;
    }
}