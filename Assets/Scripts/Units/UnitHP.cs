using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{
    [SerializeField] private int currentHP;
    [SerializeField] private int maxHP = 1;
    public delegate void DeathHandle();
    public event DeathHandle OnDeath;
    public void Init()
    {
        currentHP = maxHP;
    }
    public void Damage()
    {
        Debug.Log(gameObject.name + " Taking damage");
        currentHP -= 1;
        if(currentHP <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        OnDeath?.Invoke();
    }
}
