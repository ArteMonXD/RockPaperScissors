using UnityEngine;

public abstract class Singletoon<T> : MonoBehaviour where T : class
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
}
