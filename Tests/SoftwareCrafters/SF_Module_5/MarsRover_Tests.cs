using System;
using NUnit.Framework;
using SoftwareCrafters.SF_Module_5;

namespace Tests.SoftwareCrafters.SF_Module_5;

[TestFixture]
public class MarsRover_Tests
{
    [TestCase("55", "1 0 N", "Invalid Plateau! Make sure to have two co-ordinates seperated by whitespace")]
    [TestCase("5 5", "1 0 D", "Invalid Rover position! Make sure to have two co-ordinates and a cardinal position seperated by whitespaces")]
    public void FinalRoverPosition_GivenAnInvalidInput_ThrowsException(
        string plateau,
        string rover,
        string exceptionMessage)
    {
        var result = new MarsRover();
        var act = () => result.FinalRoverPosition(plateau, rover, "");

        Assert.That(act, Throws.Exception.TypeOf<ArgumentException>()
            .With.Message.EqualTo(exceptionMessage));
    }

    [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
    public void FinalRoverPosition_GivenValidParameters_ReturnsCorrectPosition(
        string plateau,
        string roverPosition,
        string roverInstructions,
        string expectedOutcome)
    {
        var rover = new MarsRover();
        var result = rover.FinalRoverPosition(plateau, roverPosition, roverInstructions);

        Assert.AreEqual(expectedOutcome, result);
    }
}