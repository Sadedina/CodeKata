using SoftwareCrafters.SF_Module_5.Models_MarsRover;

namespace SoftwareCrafters.SF_Module_5;

public static class Converter
{
    public static bool TryParseRoverPosition(string coordinate, out Rover rover)
    {
        rover = new Rover();

        var hasPosition = TryParsePlateau(coordinate, out var position);

        if (hasPosition is false)
            return false;

        rover.XCoordinates = position.XCoordinates;
        rover.YCoordinates = position.YCoordinates;

        var hasCompass = TryParseCompass(coordinate, out var compass);

        if (hasCompass is false)
            return false;

        rover.CompassCoordinates = compass;
        return true;
    }

    public static bool TryParsePlateau(string coordinate, out Plateau plateau)
    {
        plateau = new Plateau();

        if (!coordinate.Contains(' '))
            return false;

        var coordinates = coordinate.Split(' ');

        if (coordinates.Any(c => c.Equals("")))
            return false;

        var x = ConvertToInt(coordinates[0], out var xCoordinate);
        var y = ConvertToInt(coordinates[1], out var yCoordinate);

        if (x == false || y == false)
            return false;

        plateau = new Plateau(xCoordinate, yCoordinate);
        return true;
    }

    public static bool TryParseCompass(string coordinate, out Compass compass)
    {
        compass = new Compass();
        var sanitisedCoordinate = coordinate.Trim().LastOrDefault().ToString().ToUpper();

        if (sanitisedCoordinate is "N")
        {
            compass = Compass.N;
            return true;
        }

        if (sanitisedCoordinate is "W")
        {
            compass = Compass.W;
            return true;
        }

        if (sanitisedCoordinate is "S")
        {
            compass = Compass.S;
            return true;
        }

        if (sanitisedCoordinate is "E")
        {
            compass = Compass.E;
            return true;
        }

        return false;
    }

    private static bool ConvertToInt(string coordinate, out int parsedCoordinate)
    {
        var isNotInteger = !int.TryParse(coordinate, out int intCoordinate);
        parsedCoordinate = intCoordinate;

        if (isNotInteger)
            return false;

        return true;
    }
}