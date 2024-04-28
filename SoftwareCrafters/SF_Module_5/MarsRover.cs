namespace SoftwareCrafters.SF_Module_5;

public class MarsRover
{
    private static readonly string InvalidPlateauCoordinate = "Invalid Plateau! Make sure to have two co-ordinates seperated by whitespace";
    private static readonly string InvalidRoverPositionCoordinate = "Invalid Rover position! Make sure to have two co-ordinates and a cardinal position seperated by whitespaces";

    public string FinalRoverPosition(
        string stringPlateau,
        string stringRoverPosition,
        string roverInstructions)
    {
        var hasValidPlateau = Converter.TryParsePlateau(stringPlateau, out var plateau);
        ValidateCoordinates(hasValidPlateau, InvalidPlateauCoordinate);

        var hasValidRoverPosition = Converter.TryParseRoverPosition(stringPlateau, out var roverPosition);
        ValidateCoordinates(hasValidRoverPosition, InvalidRoverPositionCoordinate);

        throw new NotImplementedException();
    }

    private void ValidateCoordinates(bool isValid, string exceptionMessage)
    {
        if (!isValid)
            throw new ArgumentException(exceptionMessage);
    }
}