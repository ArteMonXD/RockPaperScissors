using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int m_MaxNumberBuff;
    public int MaxCountBuff => m_MaxNumberBuff;
    [Serializable]
    public struct InventoryBuffSlotInfo
    {
        public int BuffID;
        public int NumberUse;

        public InventoryBuffSlotInfo(int buffID, int numberUse)
        {
            BuffID = buffID;
            NumberUse = numberUse;
        }

        public void SetData(BuffData buffData)
        {
            BuffID = buffData.BuffID;
            NumberUse = buffData.NumberUse;
        }

        public bool Use()
        {
            NumberUse--;
            if(NumberUse <= 0)
            {
                BuffID = -1;
                NumberUse = 0;
                return true;
            }
            return false;
        }
    }
    [SerializeField] private InventoryBuffSlotInfo[] m_AvailableBuffsID;
    [SerializeField] private int m_CurrentCountAvailableBuffs;
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= m_MaxNumberBuff)
            {
                return -1;
            }
            else
            {
                return m_AvailableBuffsID[index].BuffID;
            }
        }
    }
    [SerializeField] private Buff_Storage m_BuffStorage;
    private BattleSystem m_BattleSystem;
    private BuffUnitSystem m_BuffSystem;
    public delegate void OnChangeInventory(int inventoryIndex);
    public event OnChangeInventory OnChangeInventoryEvent;
    public void Init()
    {
        m_BattleSystem = BattleSystem.Instance;
        m_BuffSystem = GetComponent<BuffUnitSystem>();
        m_AvailableBuffsID = new InventoryBuffSlotInfo[m_MaxNumberBuff];
        for(int i = 0; i<m_AvailableBuffsID.Length; i++)
        {
            m_AvailableBuffsID[i] = new InventoryBuffSlotInfo(-1, 0);
        }
        m_BattleSystem.OnPlayerWinBattleEvent += GetNewRandomBuff;
    }

    private void GetNewRandomBuff()
    {
        if(m_CurrentCountAvailableBuffs == m_MaxNumberBuff)
        {
            return;
        }

        int randomBuffID = UnityEngine.Random.Range(0, m_BuffStorage.BuffCount);
        int firstVoidIndex = Array.FindIndex(m_AvailableBuffsID, b => b.BuffID == -1);
        BuffData buffData = m_BuffStorage.GetBuffDataForID(randomBuffID);
        m_AvailableBuffsID[firstVoidIndex].SetData(buffData);
        OnChangeInventoryEvent?.Invoke(firstVoidIndex);
        m_CurrentCountAvailableBuffs++;
    }
    private void UseBuff(int buffID)
    {
        m_BuffSystem.BuffUse(buffID);
    }
    public void WasteBuff(int indexInventory)
    {
        int selectBuffID = m_AvailableBuffsID[indexInventory].BuffID;
        if(selectBuffID == -1)
        {
            return;
        }
        UseBuff(selectBuffID);
        bool status = m_AvailableBuffsID[indexInventory].Use();
        OnChangeInventoryEvent?.Invoke(indexInventory);
        if (status)
        {
            m_CurrentCountAvailableBuffs--;
        }
    }
    private void OnDestroy()
    {
        m_BattleSystem.OnPlayerWinBattleEvent -= GetNewRandomBuff;
    }
    public void DataSeter(int index, ref BuffSlot buffSlot)
    {
        int selectBuffID = m_AvailableBuffsID[index].BuffID;
        if(selectBuffID == -1)
        {
            buffSlot.SetData("", 0, index, this);
        }
        else
        {
            BuffData buffData = m_BuffStorage.GetBuffDataForID(selectBuffID);
            int currentBuffNumber = m_AvailableBuffsID[index].NumberUse;
            buffSlot.SetData(buffData.BuffName, currentBuffNumber, index, this);
        }
    }
}
