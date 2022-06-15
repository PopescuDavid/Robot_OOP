namespace Robot.Object;

/**
 * Represents an entity that can be alive and has health.
 */
public abstract class LivingEntity : IEntity
{
    public int MaxHealth { get; }
    public int Health { get; set; }
    public bool IsAlive { get; private set; }
    
    public LivingEntity(int maxHealth)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        IsAlive = true;
    }

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health > 0) return;
        
        Health = 0;
        IsAlive = false;
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if (Health > 0)
        {
            IsAlive = true;
        }
    }

    public void Revive()
    {
        if (IsAlive) return;
        
        Health = MaxHealth;
        IsAlive = true;
    }
}