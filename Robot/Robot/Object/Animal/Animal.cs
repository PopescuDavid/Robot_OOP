namespace Robot.Object.Animal;

public class Animal : LivingEntity
{
    public AnimalType AnimalType { get; }
    
    public Animal(AnimalType type, int maxHealth) : base(maxHealth)
    {
        AnimalType = type;
    }
    
    public override string ToString()
    {
        return $"Animal[Type = {AnimalType} Health = {Health}, MaxHealth = {MaxHealth}, IsAlive = {IsAlive}]";
    }
}