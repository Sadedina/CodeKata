namespace Tests.CodeWars;

[TestFixture]
public class CW13_Tests
{

    [TestCase("03:30", 1, "03:30")]
    [TestCase("12:56", 1, "01:00")]

    [TestCase("07:22", 1, "07:30")]
    [TestCase("12:22", 2, "12:45")]
    [TestCase("01:30", 2, "01:45")]
    [TestCase("04:01", 10, "05:30")]
    [TestCase("03:38", 19, "06:00")]
    public void SimpleTests(string initialTime, int chimes, string finalTime)
    {
        Assert.AreEqual(finalTime, CodeWar13.CuckooClock(initialTime, chimes));
    }

    [TestCase("10:00", 1, "10:00")]
    [TestCase("10:00", 10, "10:00")]
    [TestCase("10:00", 11, "10:15")]
    [TestCase("10:00", 13, "10:45")]
    [TestCase("10:00", 20, "11:00")]
    public void HourTests(string initialTime, int chimes, string finalTime)
    {
        Assert.AreEqual(finalTime, CodeWar13.CuckooClock(initialTime, chimes));
    }

    [TestCase("12:30", 1, "12:30")]
    [TestCase("12:30", 2, "12:45")]
    [TestCase("12:30", 3, "01:00")]
    [TestCase("12:30", 4, "01:15")]
    [TestCase("09:53", 50, "02:30")]
    public void TwelveTests(string initialTime, int chimes, string finalTime)
    {
        Assert.AreEqual(finalTime, CodeWar13.CuckooClock(initialTime, chimes));
    }

    [TestCase("08:17", 113, "08:00")]
    [TestCase("08:17", 114, "08:15")]
    [TestCase("08:17", 115, "08:30")]
    [TestCase("08:17", 150, "11:00")]
    [TestCase("08:17", 200, "05:45")]
    public void AroundTheClockTests(string initialTime, int chimes, string finalTime)
    {
        Assert.AreEqual(finalTime, CodeWar13.CuckooClock(initialTime, chimes));
    }
}