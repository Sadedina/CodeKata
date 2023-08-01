using CodeKata.Asos;
using FluentAssertions;
using Xunit;

namespace Tests.CodeKata.Asos
{
    public class CK12_Tests
    {
        [Theory]
        [InlineData(10, 23)]
        [InlineData(20, 78)]
        [InlineData(30, 195)]
        [InlineData(40, 368)]
        public void ValidatePlayersHand_WhenValidHandIsGiven_NoExceptionisThrown(int limit, int expectedResult)
        {
            var result = CodeKata12.MultipleOfThreeAndFive(limit);

            result.Should().Be(expectedResult);
        }
    }
}