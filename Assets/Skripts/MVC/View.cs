using UnityEngine;

public abstract class View : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;

    private float currentHP = 100;
    private float maxHP = 100;

    public virtual void OnHealthChanged(float hp, float maxHP)
    {
        currentHP = hp;
        this.maxHP = maxHP;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        healthBar = GetComponent<HealthBar>();
    }

    public void Update()
    {
        healthBar.HealthBarRenderer(currentHP, maxHP);
    }
}
