using UnityEngine;
using UnityEngine.Events;

internal class OnSkinChangedInteracter : InceracterListener<SkinCarMover>
{
    [SerializeField] private CurrentCarHandler _currentCarHandler;

    public UnityAction<CarType> Changed;
    
    protected override void OnInteracted(CarType val)
    {
        Changed?.Invoke(val);
    }
}