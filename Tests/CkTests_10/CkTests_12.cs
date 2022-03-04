using CodeKata;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CkTests_12
    {
        [Theory]
        [InlineData(10, 23)]
        [InlineData(20, 78)]
        [InlineData(30, 195)]
        [InlineData(40, 368)]
        public void ValidatePlayersHand_WhenValidHandIsGiven_NoExceptionisThrown(int limit, int expectedResult)
        {
            var result = CodeKata_12.MultipleOfThreeAndFive(limit);

            result.Should().Be(expectedResult);
        }
    }
}