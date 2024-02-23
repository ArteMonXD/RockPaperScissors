using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetup : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private UnitHP hP;
    private void Start()
    {
        Setup();
    }
    public void Setup()
    {
        hP.Init();
        unit.Init();
    }
}
