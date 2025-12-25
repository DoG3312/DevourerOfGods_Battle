using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]protected BaseStats stats;
    public bool invulnerability = false;
    public bool playerOrBoss;
    protected Model model;
    protected View view;

    protected virtual void Awake()
    {
        view = GetComponent<View>();
    }

    public void ApplyHealing(float amount)
    {
        model.ApplyHealing(amount);
        view.healthBar.UpdateHealthBar(model.HP, model.stats.maxHeals);
    }

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.healthBar.UpdateHealthBar(model.HP, model.stats.maxHeals);
        if(model.stats.invulnerabilityTime > 0) OnInvulnerability(model.stats.invulnerabilityTime);
    }

    public void OnInvulnerability(float invulnerabilityTime)
    {
        invulnerability = true;
        StartCoroutine(OnInvulnerability_IE(invulnerabilityTime));
    }

    private IEnumerator OnInvulnerability_IE(float invulnerabilityTime)
    {
        yield return new WaitForSeconds(invulnerabilityTime);
        invulnerability = false;
    }
}
