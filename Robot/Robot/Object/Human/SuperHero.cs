using System.Collections.Generic;

namespace Robot.Object.Human;

public class SuperHero : Human
{
    public List<SuperPower> SuperPowers { get; }
    
    public SuperHero(string name, int maxHealth, int age, List<SuperPower> superPower) : base(name, maxHealth, age)
    {
        SuperPowers = superPower;
    }
    
    public override string ToString()
    {
        return $"SuperHero[Name = {Name}, Age = {Age}, Health = {Health}, MaxHealth = {MaxHealth}, IsAlive = {IsAlive}]";
    }
}