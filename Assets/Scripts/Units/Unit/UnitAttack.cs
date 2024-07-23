using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : BuffHandler
{
    [SerializeField] private int m_DefaultDamageValue = 1;
    [SerializeField] private int m_CurrentDamageValue = 1;

    private bool m_DoubleDamageBuff = false;

    public void UpDamage(int value)
    {
        if (m_DoubleDamageBuff)
        {
            return;
        }
        m_CurrentDamageValue = m_DefaultDamageValue * 2;
        m_DoubleDamageBuff = true;
    }

    public int GetDamageValue()
    {
        int returnValue = m_CurrentDamageValue;
        if (m_DoubleDamageBuff)
        {
            m_CurrentDamageValue = m_DefaultDamageValue;
            m_DoubleDamageBuff = false;
            BuffUseEvent(0);
        }
        return returnValue;
    }
}
