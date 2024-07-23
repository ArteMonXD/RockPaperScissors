using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffHandler : MonoBehaviour
{
    public delegate void BuffHandlerUse(int id);
    public event BuffHandlerUse OnBuffHadlerUseEvent;

    protected virtual void BuffUseEvent(int id)
    {
        OnBuffHadlerUseEvent?.Invoke(id);
    }
}
