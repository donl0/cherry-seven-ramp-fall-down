using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CurrentCarHandler : SavedObject<CurrentCarHandler>
{
    private const string SAVEKEY = "CurrentCar";
    
    [SerializeField] private CarType _car;

    public CarType Car => _car;

    public UnityAction<CarType> Changed;

    public CurrentCarHandler() : base(SAVEKEY)
    {
    }

    public void ChangeCar(CarType car)
    {
        _car = car;
        Save();
        Changed?.Invoke(car);
    }

    protected override void OnLoad(CurrentCarHandler loadedObject)
    {
        _car = loadedObject._car;
    }
}
