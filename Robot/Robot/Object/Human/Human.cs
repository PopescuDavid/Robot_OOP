namespace Robot.Object.Human;

public class Human : LivingEntity
{
    public string Name { get; }
    public int Age { get; }
    
    public Human(string name, int maxHealth, int age) : base(maxHealth)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Human[Name = {Name}, Age = {Age}, Health = {Health}, MaxHealth = {MaxHealth}, IsAlive = {IsAlive}]";
    }
}