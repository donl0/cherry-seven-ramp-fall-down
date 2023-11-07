using UnityEngine;

public class CarBuilder: MonoBehaviour , ICarBuilder
{
    [SerializeField] private Transform _container;

    [SerializeField] private CarPrefabs _typesPrefabs;
    
    private CurrentCarHandler _currentCar;

    public GameObject Build(Vector3 position)
    {
        _currentCar = new CurrentCarHandler();
        _currentCar.Load();
        _typesPrefabs.TryGetPrefab(_currentCar.Car, out GameObject prefab);
        var spawned = Instantiate(prefab, position, Quaternion.identity, _container);

        return spawned;
    }
}