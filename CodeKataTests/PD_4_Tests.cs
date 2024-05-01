namespace PersonalDevelopment.Tests;

public class PD_4_Tests
{
    [Test, Description("It should return correct text")]
    public void SampleTest()
    {
        Assert.AreEqual("no one likes this", PD_4.Likes(new string[0]));
        Assert.AreEqual("Peter likes this", PD_4.Likes(new string[] { "Peter" }));
        Assert.AreEqual("Jacob and Alex like this", PD_4.Likes(new string[] { "Jacob", "Alex" }));
        Assert.AreEqual("Max, John and Mark like this", PD_4.Likes(new string[] { "Max", "John", "Mark" }));
        Assert.AreEqual("Alex, Jacob and 2 others like this", PD_4.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" }));
    }
}