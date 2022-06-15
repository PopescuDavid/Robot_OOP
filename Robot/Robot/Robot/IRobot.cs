using Robot.Object;

namespace Robot.Robot;

/**
 * Represents a robot.
 */
public interface IRobot : IEntity
{
    void Initialize();
    void Deactivate();
}