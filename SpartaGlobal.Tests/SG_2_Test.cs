namespace SpartaGlobal.Tests;

public class SG_2_Test
{
    [Test]
    public void GivenAnArrayOfSizeZero_ArrayInt_ReturnsException()
    {
        int[] anArray = new int[0] { };
        Assert.That(() => SG_2.ArrayInt(anArray), Throws.TypeOf<ArgumentException>()
            .With.Message.Contain("Cannot have a large number with an empty list!"));
    }

    [Test]
    public void GivenAnArrayOfSizeOne_ArrayInt_ReturnsNumberInArray()
    {
        int[] anArray = new int[1] { 2 };
        Assert.That(SG_2.ArrayInt(anArray), Is.EqualTo(2));
    }

    [Test]
    public void GivenAnArray_ArrayInt_ReturnsLargestNumberInArray()
    {
        int[] anArray = new int[6] { 3, 56, 34, 97, 52, 16 };
        Assert.That(SG_2.ArrayInt(anArray), Is.EqualTo(97));
    }

    [Test]
    public void GivenAnotherArray_ArrayInt_ReturnsLargestNumberInArray()
    {
        int[] anArray = new int[6] { 3, 56, 34, 97, 52, 160 };
        Assert.That(SG_2.ArrayInt(anArray), Is.EqualTo(160));
    }

    [Test]
    public void GivenAThirdArray_ArrayInt_ReturnsLargestNumberInArray()
    {
        int[] anArray = new int[6] { 103, 56, 34, 97, 52, 16 };
        Assert.That(SG_2.ArrayInt(anArray), Is.EqualTo(103));
    }
}