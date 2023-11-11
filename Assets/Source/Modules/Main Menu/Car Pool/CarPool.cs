using System.Collections.Generic;
using UnityEngine;

internal class CarPool: MonoBehaviour , IPool<CarType>
{
    [SerializeField] private CarPrefabs _cars;
    [SerializeField] private Transform _cotainer;
    
    private Dictionary<CarType, GameObject> _carPrefab = new Dictionary<CarType, GameObject>();
    
    private void Awake()
    {
        InitCars();

        SetCarProperties();
    }

    public GameObject GetObject(CarType value)
    {
        var result = _carPrefab[value];
        
        return result;
    }

    private void InitCars()
    {
        foreach (var car in _cars.Cars)
        {
            var spawned = Instantiate(car.Prefab, _cotainer);
            _carPrefab.Add(car.Type, spawned);
            spawned.SetActive(false);
        }
    }

    private void SetCarProperties()
    {
        foreach (var prefab in _carPrefab.Values)
        {
            Destroy(prefab.GetComponentInChildren<Camera>().gameObject);
            prefab.GetComponentInChildren<Rigidbody>().useGravity = false;
            prefab.GetComponentInChildren<Rigidbody>().interpolation = RigidbodyInterpolation.None;
            prefab.GetComponentInChildren<MoveController>().Activate();
        }
    }
}
