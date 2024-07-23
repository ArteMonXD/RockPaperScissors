using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExecuteButton : MonoBehaviour
{
    public virtual void Execute()
    {
        Task();
    }

    protected abstract void Task();
}
