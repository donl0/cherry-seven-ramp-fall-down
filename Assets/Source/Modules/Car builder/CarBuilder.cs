using UnityEngine;

public class CarBuilder: MonoBehaviour , ICarBuilder
{
    [SerializeField] private Transform _container;
    
    [SerializeField] private CurrentCarHandler _currentCar;
    [SerializeField] private CarPrefabs _typesPrefabs;

    public GameObject Build(Vector3 position)
    {
        _typesPrefabs.TryGetPrefab(_currentCar.Load(), out GameObject prefab);
        var spawned = Instantiate(prefab, position, Quaternion.identity, _container);

        return spawned;
    }
}