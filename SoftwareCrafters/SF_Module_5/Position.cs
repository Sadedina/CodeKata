using SoftwareCrafters.SF_Module_5.Models_MarsRover;

namespace SoftwareCrafters.SF_Module_5;
public interface IPosition
{
    public Rover NextMove(Rover rover, string instructions);
}

public class Position : IPosition
{
    public Rover NextMove(Rover rover, string instructions)
    {
        if (instructions == "L")
            return RotateAntiClockwise(rover);

        if (instructions == "R")
            return RotateClockwise(rover);

        return Advance(rover);
    }

    private static Rover RotateAntiClockwise(Rover rover)
    {
        if (rover.CompassCoordinates == Compass.N)
        {
            rover.CompassCoordinates = Compass.W;
            return rover;
        }

        if (rover.CompassCoordinates == Compass.W)
        {
            rover.CompassCoordinates = Compass.S;
            return rover;
        }

        if (rover.CompassCoordinates == Compass.S)
        {
            rover.CompassCoordinates = Compass.E;
            return rover;
        }

        rover.CompassCoordinates = Compass.N;
        return rover;
    }

    private static Rover RotateClockwise(Rover rover)
    {
        if (rover.CompassCoordinates == Compass.N)
        {
            rover.CompassCoordinates = Compass.E;
            return rover;
        }

        if (rover.CompassCoordinates == Compass.E)
        {
            rover.CompassCoordinates = Compass.S;
            return rover;

        }

        if (rover.CompassCoordinates == Compass.S)
        {
            rover.CompassCoordinates = Compass.W;
            return rover;
        }

        rover.CompassCoordinates = Compass.N;
        return rover;
    }

    private static Rover Advance(Rover rover)
    {
        if (rover.CompassCoordinates == Compass.N)
            rover.YCoordinates++;

        if (rover.CompassCoordinates == Compass.W)
            rover.XCoordinates--;

        if (rover.CompassCoordinates == Compass.S)
            rover.YCoordinates--;

        if (rover.CompassCoordinates == Compass.E)
            rover.XCoordinates++;

        return rover;
    }
}