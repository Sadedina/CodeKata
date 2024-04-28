using NUnit.Framework;
using SoftwareCrafters.SF_Module_5;
using SoftwareCrafters.SF_Module_5.Models_MarsRover;

namespace Tests.SoftwareCrafters.SF_Module_5;

[TestFixture]
public class Position_Tests
{
    private readonly Position position = new();

    [TestCase(Compass.N, 3, 4)]
    [TestCase(Compass.W, 2, 3)]
    [TestCase(Compass.S, 3, 2)]
    [TestCase(Compass.E, 4, 3)]
    public void Next_GivenInputM_AndACardinalDirection_ReturnsCorrectRoverPosition(
        Compass compassCoordinate,
        int expectedXCoordinate,
        int expectedYCoordinate)
    {
        var rover = CreateRover(3, 3, compassCoordinate);
        var roverInstructions = "M";

        var result = position.NextMove(rover, roverInstructions);

        Assert.AreEqual(expectedXCoordinate, result.XCoordinates);
        Assert.AreEqual(expectedYCoordinate, result.YCoordinates);
        Assert.AreEqual(compassCoordinate, result.CompassCoordinates);
    }

    [TestCase(Compass.N, Compass.W)]
    [TestCase(Compass.W, Compass.S)]
    [TestCase(Compass.S, Compass.E)]
    [TestCase(Compass.E, Compass.N)]
    public void Next_GivenInputL_AndACardinalDirection_ReturnsCorrectRoverPosition(
        Compass compassCoordinate,
        Compass expectedCompass)
    {
        var rover = CreateRover(3, 3, compassCoordinate);
        var roverInstructions = "L";

        var result = position.NextMove(rover, roverInstructions);

        Assert.AreEqual(expectedCompass, result.CompassCoordinates);
        Assert.AreEqual(3, result.XCoordinates);
        Assert.AreEqual(3, result.YCoordinates);
    }

    [TestCase(Compass.N, Compass.E)]
    [TestCase(Compass.E, Compass.S)]
    [TestCase(Compass.S, Compass.W)]
    [TestCase(Compass.W, Compass.N)]
    public void Next_GivenInputR_AndACardinalDirection_ReturnsCorrectRoverPosition(
        Compass compassCoordinate,
        Compass expectedCompass)
    {
        var rover = CreateRover(3, 3, compassCoordinate);
        var roverInstructions = "R";

        var result = position.NextMove(rover, roverInstructions);

        Assert.AreEqual(expectedCompass, result.CompassCoordinates);
        Assert.AreEqual(3, result.XCoordinates);
        Assert.AreEqual(3, result.YCoordinates);
    }

    private Rover CreateRover(int xCoordinate, int yCoordinate, Compass compass)
        => new(xCoordinate, yCoordinate, compass);
}