using UnityEngine;

public abstract class Actor<T>: MonoBehaviour
{
    protected T Sharer;
    
    protected virtual void Awake()
    {
        Sharer = GetComponent<T>();
    }
}