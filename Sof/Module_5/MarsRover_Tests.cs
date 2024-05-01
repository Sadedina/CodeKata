using Moq;
using SoftwareCrafters.Module_5;
using SoftwareCrafters.Module_5.Models_MarsRover;

namespace Tests.SoftwareCrafters.Tests.Module_5;

[TestFixture]
public class MarsRover_Tests
{
    private readonly Mock<IPosition> mockPosition = new();
    private readonly string validPlateau = "5 5";
    private readonly string validRover = "5 5 N";
    private readonly string validInstructions = "M";
    private MarsRover marsRover;
    public MarsRover_Tests() => marsRover = new MarsRover(mockPosition.Object);

    [Test]
    public void FinalRoverPosition_GivenInvalidPlateau_ThrowsException()
    {
        var plateau = "55";
        var exceptionMessage = "Invalid Plateau! Make sure to have two co-ordinates seperated by whitespace";
        var act = () => marsRover.FinalRoverPosition(plateau, validRover, validInstructions);

        Assert.That(act, Throws.Exception.TypeOf<ArgumentException>()
            .With.Message.EqualTo(exceptionMessage));
    }

    [Test]
    public void FinalRoverPosition_GivenInvalidRoverPosition_ThrowsException()
    {
        var roverPosition = "1 0 D";
        var exceptionMessage = "Invalid Rover position! Make sure to have two co-ordinates and a cardinal position seperated by whitespaces";
        var act = () => marsRover.FinalRoverPosition(validPlateau, roverPosition, validInstructions);

        Assert.That(act, Throws.Exception.TypeOf<ArgumentException>()
            .With.Message.EqualTo(exceptionMessage));
    }

    [TestCase("T")]
    [TestCase("M M")]
    [TestCase("m")]
    public void FinalRoverPosition_GivenInstructions_ThrowsException(string instructions)
    {
        var exceptionMessage = "Invalid Rover instructions! Make sure instructions contains only 'M', 'L' or 'R' without whitespaces";
        var act = () => marsRover.FinalRoverPosition(validPlateau, validRover, instructions);

        Assert.That(act, Throws.Exception.TypeOf<ArgumentException>()
            .With.Message.EqualTo(exceptionMessage));
    }

    [TestCase(0, 0, Compass.N, "M", 0, 1, Compass.N)]
    public void FinalRoverPosition_GivenValidParameters_ReturnsCorrectPosition(
        int xCoordinate,
        int yCoordinate,
        Compass compassCoordinate,
        string instructions,
        int expectedXCoordinate,
        int expectedYCoordinate,
        Compass expectedCompassCoordinate)
    {
        var rover = CreateRover(xCoordinate, yCoordinate, compassCoordinate);
        var expectedRover = CreateRover(expectedXCoordinate, expectedYCoordinate, expectedCompassCoordinate);

        var position = new Position();
        marsRover = new MarsRover(position);

        var result = marsRover.FinalRoverPosition(validPlateau, RoverToString(rover), instructions);

        Assert.AreEqual(RoverToString(expectedRover), result);
    }

    [Test]
    public void FinalRoverPosition_GivenTestCase_ReturnsCorrectPosition()
    {
        var plateau = "5 5";
        var rover = "1 2 N";
        var instructions = "LMLMLMLMM";
        var expectedPosition = "1 3 N";

        var position = new Position();
        marsRover = new MarsRover(position);

        var result = marsRover.FinalRoverPosition(plateau, rover, instructions);

        Assert.AreEqual(expectedPosition, result);
    }

    [TestCase(3, 5, Compass.N)]
    [TestCase(0, 3, Compass.W)]
    [TestCase(3, 0, Compass.S)]
    [TestCase(5, 3, Compass.E)]
    public void FinalRoverPosition_GivenInstructionsMoveRoverOutOfThePlateau_ThrowException(
        int xCoordinate,
        int yCoordinate,
        Compass compassCoordinate)
    {
        var plateau = "5 5";
        var instructions = "M";

        var rover = CreateRover(xCoordinate, yCoordinate, compassCoordinate);
        var exceptionMessage = "Invalid Instructions! The instructions given puts the rover out of bounds";

        var position = new Position();
        marsRover = new MarsRover(position);

        var act = () => marsRover.FinalRoverPosition(plateau, RoverToString(rover), instructions);

        Assert.That(act, Throws.Exception.TypeOf<ArgumentException>()
            .With.Message.EqualTo(exceptionMessage));
    }

    private Rover CreateRover(int xCoordinate, int yCoordinate, Compass compass)
        => new(xCoordinate, yCoordinate, compass);

    private string RoverToString(Rover rover)
        => $"{rover.XCoordinates} {rover.YCoordinates} {rover.CompassCoordinates}";
}