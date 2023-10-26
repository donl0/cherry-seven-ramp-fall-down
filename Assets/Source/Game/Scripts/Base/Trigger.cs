using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class Trigger<T> : MonoBehaviour where T : MonoBehaviour
{
    public event UnityAction<T> Enter;
    public event UnityAction<T> Exit;
 
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out T triggered))
        {
            Enter?.Invoke(triggered);

            OnEnter(triggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out T triggeredObject))
        {
            Exit?.Invoke(triggeredObject);

            OnExit(triggeredObject);
        }
    }
    
    protected virtual void OnEnter(T triggered) { }
    protected virtual void OnExit(T triggered) { }
}