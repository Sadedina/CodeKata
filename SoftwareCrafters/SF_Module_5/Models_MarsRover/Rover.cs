namespace SoftwareCrafters.SF_Module_5.Models_MarsRover;

public record Rover
{
    public Rover(
        int xCoordinates,
        int yCoordinates,
        Compass compassCoordinates)
    {
        XCoordinates = xCoordinates;
        YCoordinates = yCoordinates;
        CompassCoordinates = compassCoordinates;
    }

    public Rover()
    {
        XCoordinates = null;
        YCoordinates = null;
        CompassCoordinates = null;
    }

    public int? XCoordinates { get; set; }
    public int? YCoordinates { get; set; }
    public Compass? CompassCoordinates { get; set; }
}