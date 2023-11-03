using UnityEngine;

[CreateAssetMenu(menuName = "current car handler")]
public class CurrentCarHandler : ScriptableObject
{
    private CarType _car;

    public void Save(CarType car)
    {
        _car = car;
    }

    public CarType Load()
    {
        return _car;
    }
}
