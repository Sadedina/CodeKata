using SoftwareCrafters.Module_5.Models_MarsRover;

namespace SoftwareCrafters.Module_5;

public class MarsRover : Position
{
    private static readonly string InvalidPlateauCoordinate = "Invalid Plateau! Make sure to have two co-ordinates seperated by whitespace";
    private static readonly string InvalidRoverPositionCoordinate = "Invalid Rover position! Make sure to have two co-ordinates and a cardinal position seperated by whitespaces";
    private static readonly string InvalidInstructionsCoordinate = "Invalid Rover instructions! Make sure instructions contains only 'M', 'L' or 'R' without whitespaces";
    private static readonly string OutOfBoundsInstuctions = "Invalid Instructions! The instructions given puts the rover out of bounds";
    private readonly IPosition position = new Position();

    public MarsRover(IPosition position) => this.position = position;

    public string FinalRoverPosition(
        string stringPlateau,
        string stringRover,
        string instructions)
    {
        var hasValidPlateau = Converter.TryParsePlateau(stringPlateau, out var plateau);
        ValidateCoordinates(hasValidPlateau, InvalidPlateauCoordinate);

        var hasValidRoverPosition = Converter.TryParseRoverPosition(stringRover, out var rover);
        ValidateCoordinates(hasValidRoverPosition, InvalidRoverPositionCoordinate);

        ValidateInstructions(instructions);

        rover = PerformInstructions(rover, instructions, plateau);

        return $"{rover.XCoordinates} {rover.YCoordinates} {rover.CompassCoordinates}";
    }

    private static void ValidateCoordinates(bool isValid, string exceptionMessage)
    {
        if (!isValid)
            throw new ArgumentException(exceptionMessage);
    }

    private static void ValidateInstructions(string instructions)
    {
        var remainderContent = instructions.Replace("M", "").Replace("L", "").Replace("R", "");

        if (!String.IsNullOrEmpty(remainderContent))
            throw new ArgumentException(InvalidInstructionsCoordinate);
    }

    private static void ValidateInstructionsAgainstPlateau(Rover rover, Plateau plateau)
    {
        var roverIsOutOfBounds = rover.XCoordinates < 0
            || rover.XCoordinates > plateau.XCoordinates
            || rover.YCoordinates < 0
            || rover.YCoordinates > plateau.YCoordinates;

        if (roverIsOutOfBounds)
            throw new ArgumentException(OutOfBoundsInstuctions);
    }

    private Rover PerformInstructions(Rover rover, string instructions, Plateau plateau)
    {
        foreach (var instruct in instructions)
        {
            rover = position.NextMove(rover, instruct.ToString());
            ValidateInstructionsAgainstPlateau(rover, plateau);
        }

        return rover;
    }
}