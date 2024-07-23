using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff Storage", menuName = "Scriptable Objects/Buff Storage", order = 1)]
public class Buff_Storage : ScriptableObject
{
    [SerializeField] private BuffData[] m_BuffData;
    public int BuffCount => m_BuffData.Length;

    public BuffData GetBuffDataForIndex(int findIndex)
    {
        if(findIndex < 0 || findIndex >= m_BuffData.Length)
        {
            return null;
        }
        else
        {
            return m_BuffData[findIndex];
        }
    }

    public BuffData GetBuffDataForID(int findID)
    {
        BuffData findData = m_BuffData.FirstOrDefault(d => d.BuffID == findID);
        return findData;
    }
}
[Serializable]
public class BuffData
{
    [SerializeField] private string m_BuffName;
    public string BuffName => m_BuffName;
    [SerializeField] private string m_BuffDescription;
    public string BuffDescription => m_BuffDescription;
    [SerializeField] private int m_BuffID;
    public int BuffID => m_BuffID;
    public enum BuffTypeEnum { Damage, Health, Vision, Defence, Save }
    [SerializeField] private BuffTypeEnum m_BuffType;
    public BuffTypeEnum BuffType => m_BuffType;
    [SerializeField] private int m_ConventionalUnits;
    public int ConventionalUnits => m_ConventionalUnits;
    [SerializeField] private int m_NumberUse;
    public int NumberUse => m_NumberUse;
}
