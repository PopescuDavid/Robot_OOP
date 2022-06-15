using System;
using Robot.Object.Animal;
using Robot.Object.Human;
using Robot.Robot;

namespace Robot
{
  internal class Program
  {
    public static void Main()
    {
      var robot = new GiantKillerRobot();
      robot.Initialize();

      robot.Planet = Planet.Planet.Earth;
      
      robot.EyeLaserIntensity = Intensity.Kill;
      robot.AddTargetTypes(typeof(Animal), typeof(Human), typeof(SuperHero));
      
      Console.WriteLine(robot);

      while (robot.Active && robot.Planet.ContainsLife())
      {
        if (robot.CurrentTarget is {IsAlive: true})
        {
          robot.FireLaser();
        }
        else
        {
          robot.AcquireNextTarget();
        }
      }


      Console.WriteLine();
      Console.WriteLine(robot);
    }
  }
}