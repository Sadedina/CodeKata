namespace PersonalDevelopment.Tests;

public class PD16_Tests
{
    private readonly StringCalculator stringCalculator = new();

    [Test]
    public void Add_GivenEmptyString_ReturnsZero()
    {
        var result = stringCalculator.Add("");
        result.Should().Be(0);
    }

    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("3", 3)]
    public void Add_GivenStringWithoutComma_ReturnsCorrectInteger(string sentence, int expectedNum)
    {
        var result = stringCalculator.Add(sentence);
        result.Should().Be(expectedNum);
    }

    [TestCase("1,0", 1)]
    [TestCase("1,1", 2)]
    [TestCase("1,2", 3)]
    public void Add_GivenStringWithComma_ReturnsTheirSum(string sentence, int expectedNum)
    {
        var result = stringCalculator.Add(sentence);
        result.Should().Be(expectedNum);
    }

    [TestCase("1,2,3", 6)]
    [TestCase("1,2,3,4", 10)]
    [TestCase("1,2,3,4,5", 15)]
    public void Add_GivenStringWithManyCommas_ReturnsTheirSum(string sentence, int expectedNum)
    {
        var result = stringCalculator.Add(sentence);
        result.Should().Be(expectedNum);
    }

    [TestCase("1\n0", 1)]
    [TestCase("1\n1", 2)]
    [TestCase("1\n2", 3)]
    public void Add_GivenStringWithNewline_ReturnsTheirSum(string sentence, int expectedNum)
    {
        var result = stringCalculator.Add(sentence);
        result.Should().Be(expectedNum);
    }

    [TestCase("//;\n1;0", 1)]
    [TestCase("//$&\n1$&1", 2)]
    [TestCase("//$&£\n1$&£2", 3)]
    public void Add_GivenStringWithASeparator_ReturnsTheirSum(string sentence, int expectedNum)
    {
        var result = stringCalculator.Add(sentence);
        result.Should().Be(expectedNum);
    }

    [TestCase("-1", "-1")]
    [TestCase("-1,-2", "-1 -2")]
    [TestCase("1,-2,-3", "-2 -3")]
    [TestCase("//$&£\n1$&£-2", "-2")]
    public void Add_GivenStringWithNegativeNumbers_ThrowsException(string sentence, string expectedMessage)
    {
        var act = () => stringCalculator.Add(sentence);

        act.Should().Throw<ArgumentException>()
            .WithMessage($"Negatives not allowed: {expectedMessage}");
    }
}