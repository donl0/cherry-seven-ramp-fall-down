using UnityEngine;
using UnityEngine.Events;

internal class OnSkinChangedInteracter : InceracterListener<SkinCarMover>
{
    public UnityAction<CarType> Changed;
    
    protected override void OnInteracted(CarType val)
    {
        Changed?.Invoke(val);
    }
}