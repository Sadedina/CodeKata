using NUnit.Framework;
using SoftwareCrafters.SF_Module_5;
using SoftwareCrafters.SF_Module_5.Models_MarsRover;

namespace Tests.SoftwareCrafters.SF_Module_5;

[TestFixture]
public class Converter_Tests
{
    [TestCase("5 5", 5, 5)]
    [TestCase("10 5", 10, 5)]
    [TestCase("150 5", 150, 5)]
    public void TryParsePlateau_GivenValidCoordinates_ReturnsPlateau(
        string coordinate,
        int expectedXCoordinate,
        int expectedYCoordinate)
    {
        var result = Converter.TryParsePlateau(coordinate, out var plateau);

        Assert.IsTrue(result);
        Assert.AreEqual(expectedXCoordinate, plateau.XCoordinates);
        Assert.AreEqual(expectedYCoordinate, plateau.YCoordinates);
    }

    [TestCase("55")]
    [TestCase(" 5")]
    [TestCase("5 ")]
    [TestCase(" ")]
    [TestCase("x y")]
    [TestCase("5, 5")]
    [TestCase("")]
    public void TryParsePlateau_GivenInvalidCoordinates_ReturnsFalse(string coordinate)
    {
        var result = Converter.TryParsePlateau(coordinate, out _);

        Assert.IsFalse(result);
    }

    [TestCase("5N", Compass.N)]
    [TestCase(" S", Compass.S)]
    [TestCase("W ", Compass.W)]
    [TestCase("5 5 E", Compass.E)]
    public void TryParseCompass_GivenValidCoordinates_ReturnsCompass(
        string coordinate,
        Compass expectedCompassCoordinate)
    {
        var result = Converter.TryParseCompass(coordinate, out var compass);

        Assert.IsTrue(result);
        Assert.AreEqual(expectedCompassCoordinate, compass);
    }

    [TestCase("55")]
    [TestCase(" D")]
    [TestCase("5 5")]
    [TestCase("")]
    public void TryParseCompass_GivenInvalidCoordinates_ReturnsFalse(string coordinate)
    {
        var result = Converter.TryParseCompass(coordinate, out _);

        Assert.IsFalse(result);
    }

    [TestCase("5 5 N", 5, 5, Compass.N)]
    [TestCase("12 5 S", 12, 5, Compass.S)]
    [TestCase("0 1 W", 0, 1, Compass.W)]
    [TestCase("150 100 E", 150, 100, Compass.E)]
    public void TryParseRoverPosition_GivenValidCoordinates_ReturnsCompass(
        string coordinate,
        int expectedXCoordinate,
        int expectedYCoordinate,
        Compass expectedCompassCoordinate)
    {
        var result = Converter.TryParseRoverPosition(coordinate, out var rover);

        Assert.IsTrue(result);
        Assert.AreEqual(expectedXCoordinate, rover.XCoordinates);
        Assert.AreEqual(expectedYCoordinate, rover.YCoordinates);
        Assert.AreEqual(expectedCompassCoordinate, rover.CompassCoordinates);
    }

    [TestCase("55N")]
    [TestCase(" 5 N")]
    [TestCase("5 N 5")]
    [TestCase(" ")]
    [TestCase("x y N")]
    [TestCase("N")]
    [TestCase("")]
    public void TryParseRoverPosition_GivenInvalidCoordinates_ReturnsFalse(string coordinate)
    {
        var result = Converter.TryParseRoverPosition(coordinate, out _);

        Assert.IsFalse(result);
    }
}