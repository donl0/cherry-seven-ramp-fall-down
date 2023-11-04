using UnityEngine;

internal abstract class InceracterListener<T>: MonoBehaviour where T:IMainCarInteracter
{
    [SerializeField] private T _interacter;
    
    private void OnEnable()
    {
        _interacter.Interacted += OnInteracted;
    }
    
    private void OnDisable()
    {
        _interacter.Interacted -= OnInteracted;
    }
    
    protected abstract void OnInteracted(CarType val);
}
