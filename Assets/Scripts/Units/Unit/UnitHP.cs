using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : BuffHandler
{
    [SerializeField] private int currentHP;
    [SerializeField] private int maxHP = 1;
    public delegate void DeathHandle();
    public event DeathHandle OnDeath;

    private bool m_DefenceBuff;
    private int m_ReturnableDamage;
    private int m_ResistDamage;
    public void Init()
    {
        currentHP = maxHP;
    }
    public void Damage(int damageValue, Unit damageDealer)
    {
        Debug.Log(gameObject.name + " Taking damage. Damage Value: " + damageValue);
        currentHP -= damageValue;
        if (m_DefenceBuff)
        {
            ReturnDamage(damageDealer.UnitHP);
        }
        if(currentHP <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        OnDeath?.Invoke();
    }
    public void ResetHP()
    {
        currentHP = maxHP;
    }
    public void HealthHP(int value)
    {
        if(currentHP < maxHP)
        {
            currentHP += value;
        }
        BuffUseEvent(1);
    }
    public void DefenceReturnable(int returnDamageValue)
    {
        if (m_DefenceBuff)
        {
            return;
        }

        m_DefenceBuff = true;
        m_ReturnableDamage = returnDamageValue;
    }
    private void ReturnDamage(UnitHP unitHP)
    {
        if (unitHP != null)
        {
            unitHP.Damage(m_ReturnableDamage, null);
        }
        BuffUseEvent(3);
    }
}
