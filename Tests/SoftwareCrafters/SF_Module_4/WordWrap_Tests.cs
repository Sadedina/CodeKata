using NUnit.Framework;
using SoftwareCrafters.SF_Module_4;

namespace Tests.SoftwareCrafters.SF_Module_4;

[TestFixture]
public class WordWrap_Tests
{
    [TestCase(null, "")]
    [TestCase("", "")]
    public void Wrap_GivenNullOrEmptyWord_ReturnsEmpty(string word, string expectedWord)
    {
        var column = 1;
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("word", 10, "word")]
    [TestCase("pizza", 7, "pizza")]
    [TestCase("tower", 15, "tower")]
    public void Wrap_GivenAColumNumberIsBiggerThanTheWord_ReturnsWord(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("word", 4, "word")]
    [TestCase("pizza", 5, "pizza")]
    [TestCase("towers", 6, "towers")]
    public void Wrap_GivenAColumNumberIsOnTheBoundaryWord_ReturnsWord(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("wonderfull", 5, "wonde\nrfull")]
    [TestCase("spice", 3, "spi\nce")]
    [TestCase("bullseye", 7, "bullsey\ne")]
    public void Wrap_GivenAColumNumberIsSmallerThanTheWord_ReturnsWordWithNewLineInbetween(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("wonderfull", 4, "wond\nerfu\nll")]
    [TestCase("restaurant", 3, "res\ntau\nran\nt")]
    [TestCase("bullseye", 2, "bu\nll\nse\nye")]
    [TestCase("incomprehensibilities", 4, "inco\nmpre\nhens\nibil\nitie\ns")]
    public void Wrap_GivenAColumNumberIsMoreThanTwiceAsSmallThanTheWord_ReturnsWordWithNewLineInbetween(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("word word", 7, "word\nword")]
    [TestCase("pizza pizza", 8, "pizza\npizza")]
    [TestCase("tower tower", 8, "tower\ntower")]
    public void Wrap_GivenAColumNumberIsBiggerThanTheFirstWord_AndSmallerThanTheSentence_ReturnsWord(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }

    [TestCase("I love pizza", 5, "I\nlove\npizza")]
    [TestCase("Your unintentional actions are problematic.", 10, "Your\nunintentio\nnal\nactions\nare\nproblemati\nc.")]
    [TestCase("There used to be a pine tree in front of my house.", 20, "There used to be a\npine tree in front\nof my house.")]
    public void Wrap_GivenASentenceWithASmallerColumNumber_ReturnsWord(string word, int column, string expectedWord)
    {
        var result = WordWrap.Wrap(word, column);

        Assert.AreEqual(expectedWord, result);
    }
}