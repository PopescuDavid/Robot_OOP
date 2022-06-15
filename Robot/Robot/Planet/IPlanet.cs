using System.Collections.Generic;
using Robot.Object;

namespace Robot.Planet;

/**
 * Represents a planet.
 */
public interface IPlanet
{
    public string Name { get; }
    public HashSet<IEntity> Entities { get; }

    bool ContainsLife();
}