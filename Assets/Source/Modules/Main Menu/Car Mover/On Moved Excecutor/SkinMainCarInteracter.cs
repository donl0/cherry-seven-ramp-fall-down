using UnityEngine;

internal class SkinMainCarInteracter : InceracterListener<SkinCarMover>
{
    [SerializeField] private CurrentCarHandler _currentCarHandler;

    protected override void OnInteracted(CarType val)
    {
        _currentCarHandler.Save(val);
    }
}
