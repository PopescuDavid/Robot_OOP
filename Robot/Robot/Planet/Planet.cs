using System.Collections.Generic;
using System.Linq;
using Robot.Object;
using Robot.Object.Animal;
using Robot.Object.Human;

namespace Robot.Planet;

public class Planet : IPlanet
{
    public static readonly Planet Venus = new("Venus", new HashSet<IEntity>());
    public static readonly Planet Earth = new("Earth", CreateEarthEntities());
    public static readonly Planet Mars = new("Mars", new HashSet<IEntity>());

    public string Name { get; }
    public HashSet<IEntity> Entities { get; }
    
    private Planet(string name, HashSet<IEntity> entities)
    {
        Name = name;
        Entities = entities;
    }

    public bool ContainsLife()
    {
        return Entities.OfType<LivingEntity>().Any();
    }

    public bool RemoveEntity(IEntity entity)
    {
        return Entities.Remove(entity);
    }

    public override string ToString()
    {
        return $"Planet[Name = {Name}, Entities = {{{string.Join(", ", Entities)}}}]";
    }

    private static HashSet<IEntity> CreateEarthEntities()
    {
        var set = new HashSet<IEntity>
        {
            new Human("Andrei", 20, 35),
            new Human("Alexandra", 20, 72),
            new Human("Ruben", 20, 20),
            new Human("Mihai", 20, 12),
            new SuperHero("Superman", 30, 40, new List<SuperPower>
            {
                SuperPower.Flight,
                SuperPower.Invincibility,
                SuperPower.Strength,
                SuperPower.Speed
            }),
            new Animal(AnimalType.Elephant, 40),
            new Animal(AnimalType.Lion, 30),
            new Animal(AnimalType.Donkey, 10)
        };

        return set;
    }
}