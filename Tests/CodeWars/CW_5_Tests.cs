using CodeWars;
using NUnit.Framework;

namespace Tests.CodeWars;

[TestFixture]
public class CW_5_Tests
{
    [TestCase("")]
    [TestCase(" ")]
    public void ToUnderScore_GivenEmptyOrSpace_ReturnsEmpty(string word)
    {
        var result = CodeWar_5.ToUnderScore(word);

        Assert.AreEqual("", result);
    }

    [TestCase("Aa", "Aa")]
    [TestCase("aA", "a_A")]
    [TestCase("1A", "1_A")]
    public void ToUnderScore_GivenUppercase_ReturnsCorrectSentence(string word, string expectedWord)
    {
        var result = CodeWar_5.ToUnderScore(word);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("13", "13")]
    [TestCase("a1", "a_1")]
    [TestCase("a14", "a_14")]
    public void ToUnderScore_GivenNumber_ReturnsCorrectSentence(string word, string expectedWord)
    {
        var result = CodeWar_5.ToUnderScore(word);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("a_A", "a_A")]
    [TestCase("1_A", "1_A")]
    [TestCase("a_1", "a_1")]
    [TestCase("a_1_4", "a_1_4")]
    public void ToUnderScore_GivenUnderscores_ReturnsCorrectSentence(string word, string expectedWord)
    {
        var result = CodeWar_5.ToUnderScore(word);

        Assert.AreEqual(expectedWord, result);
    }

    [Test]
    public void SimpleUnitNameTests()
    {
        Assert.AreEqual("This_Is_A_Unit_Test", CodeWar_5.ToUnderScore("ThisIsAUnitTest"));
        Assert.AreEqual("This_Should_Be_Split_Correct_Into_Underscore", CodeWar_5.ToUnderScore("ThisShouldBeSplitCorrectIntoUnderscore"));
    }

    [Test]
    public void CalculationUnitNameTests()
    {
        Assert.AreEqual("Calculate_1_Plus_1_Equals_2", CodeWar_5.ToUnderScore("Calculate1Plus1Equals2"));
        Assert.AreEqual("Calculate_15_Plus_5_Equals_20", CodeWar_5.ToUnderScore("Calculate15Plus5Equals20"));
        Assert.AreEqual("Calculate_500_Divided_By_5_Equals_100", CodeWar_5.ToUnderScore("Calculate500DividedBy5Equals100"));
    }

    [Test]
    public void SpecialUnitNameTests()
    {
        Assert.AreEqual("This_Is_Already_Split_Correct", CodeWar_5.ToUnderScore("This_Is_Already_Split_Correct"));
        Assert.AreEqual("This_Is_Not_Split_Correct", CodeWar_5.ToUnderScore("ThisIs_Not_SplitCorrect"));
        Assert.AreEqual("_If_A_Test_Start_And_Ends_With_Underscore_It_Should_Be_The_Same_", CodeWar_5.ToUnderScore("_IfATestStartAndEndsWithUnderscore_ItShouldBeTheSame_"));
    }
}