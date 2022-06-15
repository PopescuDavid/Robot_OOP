namespace Robot.Robot;

public class Robot : IRobot
{
    public Planet.Planet Planet { get; set; }
    public bool Active { get; protected set; }

    public void Initialize()
    {
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public override string ToString()
    {
        return $"Robot[Active = {Active}, Planet = {Planet}]";
    }
}