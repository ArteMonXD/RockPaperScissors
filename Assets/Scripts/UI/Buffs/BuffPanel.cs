using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPanel : MonoBehaviour
{
    [SerializeField] private PlayerInventory m_PlayerInventory;
    [SerializeField] private GameObject m_BuffSlotPrefab;
    [SerializeField] private Transform m_ParentTransform;
    [SerializeField] private BuffSlot[] buffSlots;
    public void Init()
    {
        m_PlayerInventory = FindObjectOfType<PlayerInventory>();
        m_PlayerInventory.OnChangeInventoryEvent += UpdateSlot;
        GenerateSlots();
    }

    private void GenerateSlots()
    {
        buffSlots = new BuffSlot[m_PlayerInventory.MaxCountBuff];
        for (int i = 0; i < m_PlayerInventory.MaxCountBuff; i++)
        {
            GameObject slot = Instantiate(m_BuffSlotPrefab, m_ParentTransform);
            BuffSlot buffSlot = slot.GetComponent<BuffSlot>();
            m_PlayerInventory.DataSeter(i, ref buffSlot);
            buffSlots[i] = buffSlot;
        }
    }

    private void UpdateSlot(int indexUpdate)
    {
        BuffSlot buffSlot = buffSlots[indexUpdate];
        m_PlayerInventory.DataSeter(indexUpdate, ref buffSlot);
    }
}
