using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "current car handler")]
public class CurrentCarHandler : ScriptableObject
{
    private CarType _car;

    public UnityAction<CarType> Changed;
    
    public void Save(CarType car)
    {
        _car = car;
        Changed?.Invoke(car);
    }

    public CarType Load()
    {
        return _car;
    }
}
