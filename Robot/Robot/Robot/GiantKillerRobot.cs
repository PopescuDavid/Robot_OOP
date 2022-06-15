using System;
using System.Collections.Generic;
using System.Linq;
using Robot.Object;

namespace Robot.Robot;

public class GiantKillerRobot : Robot
{
    public Intensity EyeLaserIntensity { get; set; }
    public LivingEntity CurrentTarget { get; protected set; }
    public IList<Type> TargetTypes { get; }
    
    public GiantKillerRobot()
    {
        TargetTypes = new List<Type>();
    }

    public void AddTargetTypes(params Type[] types)
    {
        if (!Active) return;
        
        foreach (var type in types)
        {
            if (!type.IsSubclassOf(typeof(LivingEntity)))
            {
                throw new ArgumentException("Only LivingEntity types can be added as target types");
            }

            TargetTypes.Add(type);
        }
    }

    public void FireLaser()
    {
        if (!Active) return;
        if (!TargetTypes.Contains(CurrentTarget.GetType())) return;
        
        if (CurrentTarget is not {IsAlive: true} livingEntity) return;
        
        switch (EyeLaserIntensity)
        {
            case Intensity.Low:
                livingEntity.Damage(10/100 * livingEntity.MaxHealth);
                break;
            case Intensity.Medium:
                livingEntity.Damage(50/100 * livingEntity.MaxHealth);
                break;
            case Intensity.Kill:
                livingEntity.Damage(livingEntity.MaxHealth);
                break;
            default:
                return;
        }

        if (livingEntity.IsAlive) return;
        
        Planet.RemoveEntity(livingEntity);
        CurrentTarget = null;
    }

    public void AcquireNextTarget()
    {
        if (!Active) return;
        if (TargetTypes.Count == 0) return;
        if (!Planet.ContainsLife()) return;

        CurrentTarget = (LivingEntity) Planet.Entities.First(entity =>
            entity is LivingEntity {IsAlive: true} && TargetTypes.Contains(entity.GetType()));
    }

    public override string ToString()
    {
        return $"GiantKillerRobot[Active = {Active}, Planet = {Planet}, CurrentTarget = {CurrentTarget}, " +
               $"TargetTypes = {{{string.Join(", ", TargetTypes)}}}, EyeLaserIntensity = {EyeLaserIntensity}]";
    }
}