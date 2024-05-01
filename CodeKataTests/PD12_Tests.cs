namespace PersonalDevelopment.Tests;

public class PD12_Tests
{
    [TestCase(10, 23)]
    [TestCase(20, 78)]
    [TestCase(30, 195)]
    [TestCase(40, 368)]
    public void ValidatePlayersHand_WhenValidHandIsGiven_NoExceptionisThrown(int limit, int expectedResult)
    {
        var result = PD12.MultipleOfThreeAndFive(limit);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}