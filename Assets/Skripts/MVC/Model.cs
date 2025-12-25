using System;

public abstract class Model 
{
    public float HP;
    public BaseStats stats;

    public event Action<float, float> HealthChanged;

    public Model(BaseStats baseStats)
    {
        stats = baseStats;
        HP = stats.maxHeals;
    }

    public virtual void TakeDamage(float damage)
    {
        if (HP - damage <= 0)
        {
            HP = 0;
        }
        else
        {
            HP -= damage;
        }
        HealthChanged?.Invoke(HP, stats.maxHeals);
    }

    public void ApplyHealing(float amount)
    {
        if (HP + amount >= stats.maxHeals)
        {
            HP = stats.maxHeals;
        }
        else
        {
            HP += amount;
        }
        HealthChanged?.Invoke(HP, stats.maxHeals);
    }

}
