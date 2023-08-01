using System;
using System.Collections.Generic;
using CodeKata.Asos;
using FluentAssertions;
using Xunit;

namespace Tests.CodeKata.Asos
{
    public class CK13_Tests
    {
        [Theory]
        [MemberData(nameof(TestScript))]
        public void FindMatchingParenthesis_WhenValidSentenceAndInputGiven_ReturnsCorrectOutput(
            string sentence,
            int RightIndex,
            int LeftIndex)
        {
            var result = CodeKata13.FindMatchingParenthesis(sentence, RightIndex);

            result.Should().Be(LeftIndex);
        }

        [Theory]
        [MemberData(nameof(ExceptionTestScript))]
        public void FindMatchingParenthesis_WhenInvalidSentenceAndInputGiven_ThrowsException(
            string sentence,
            int index,
            string exceptionMessage)
        {
            Action act = () => CodeKata13.FindMatchingParenthesis(sentence, index);

            act.Should().Throw<Exception>().WithMessage(exceptionMessage);
        }

        public static IEnumerable<object[]> TestScript =>
       new List<object[]>
       {
           new object[] { "A(B", 1, -1},
           new object[] { "A)(B", 2, -1},
           new object[] { "(A)(B", 3, -1},
           new object[] { "(A)B)", 0, 2},
           new object[] { "(A(B)", 2, 4},

           new object[] { "(A)(B)", 0, 2},
           new object[] { "(A)(B)", 3, 5},

           new object[] { "A(B(C)D)", 1, 7},
           new object[] { "A(B(C)D)", 3, 5},

           new object[] { "(A)B)C(D)E)", 6, 8},

           new object[] { "(A(B)C(D)E)(F)G)", 0, 10}, //
           new object[] { "(A(B)C(D)E)(F)G)", 2, 4}, //
           new object[] { "(A(B)C(D)E)(F)G)", 6, 8}, //
           new object[] { "(A(B)C(D)E)(F)G)", 11, 13},

           new object[] { "(A(B(C(D)E)(F)G)", 11, 13},
           new object[] { "(A(B)C)D)E)F(G)", 12, 14},
           new object[] { "(A(B(C)D)E(F)G)", 10, 12 }
       };

        public static IEnumerable<object[]> ExceptionTestScript =>
        new List<object[]>
        {
            new object[] { "A)B", 0, "The index given (0) does not correspond to '(' position but found 'A'."},
            new object[] { "(A)(B)C)", 1, "The index given (1) does not correspond to '(' position but found 'A'." },
            new object[] { "(A)(B)C)", 2, "The index given (2) does not correspond to '(' position but found ')'." }
        };
    }
}