namespace SoftwareCrafters.Module_5.Models_MarsRover;

public record Plateau
{
    public Plateau(int xCoordinates, int yCoordinates)
    {
        XCoordinates = xCoordinates;
        YCoordinates = yCoordinates;
    }

    public Plateau()
    {
        XCoordinates = null;
        YCoordinates = null;
    }

    public int? XCoordinates { get; set; }
    public int? YCoordinates { get; set; }
}