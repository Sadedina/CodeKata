namespace Tests.CodeWars;

[TestFixture]
public class CW_9_Tests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, CodeWar_9.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
        Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, CodeWar_9.SortArray(new int[] { 5, 3, 1, 8, 0 }));
        Assert.AreEqual(new int[] { }, CodeWar_9.SortArray(new int[] { }));
    }

    [Test]
    public void ExtractOddNumbers_GivenAnArray_ReturnsOddNumbers()
    {
        var array = new int[] { 1, 3, 2, 8, 5, 4 };
        var result = new int[] { 1, 3, 5 };

        var sut = CodeWar_9.ExtractOddNumbers(array);

        Assert.AreEqual(result, sut);
    }

    [Test]
    public void RearrangeOddNumbers_GivenAnArray_ReturnsOddNumbers()
    {
        var array = new int[] { 1, 3, 2, 8, 5, 4 };
        var result = new int[] { 1, 2, 3, 4, 5, 8 };

        var sut = CodeWar_9.RearrangeOddNumbers(array);

        Assert.AreEqual(result, sut);
    }
}