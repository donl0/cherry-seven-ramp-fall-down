using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CurrentCarHandler : SavedObject<CurrentCarHandler>
{
    private const string SAVEKEY = "CurrentCar";
    private const CarType STARTCAR = CarType.niisan;
    
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

    protected override void OnFirstLoad()
    {
        base.OnFirstLoad();

        _car = STARTCAR;
    }
}
