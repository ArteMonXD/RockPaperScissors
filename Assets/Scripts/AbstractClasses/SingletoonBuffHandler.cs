using UnityEngine;

public class SingletoonBuffHandler<T> : MonoBehaviour where T : class
{
    private static T instance;
    public static T Instance => instance;
    private void Awake()
    {
        if (instance == null)
            instance = this as T;
        else
            Destroy(this.gameObject);
    }
    
    public delegate void BuffHandlerUse(int id);
    public event BuffHandlerUse OnBuffHadlerUseEvent;

    protected virtual void BuffUseEvent(int id)
    {
        OnBuffHadlerUseEvent?.Invoke(id);
    }
}
