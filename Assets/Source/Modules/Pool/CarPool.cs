using System.Collections.Generic;
using UnityEngine;

public class CarPool: MonoBehaviour , IPool<CarType>
{
    [SerializeField] private CarPrefabs _cars;
    [SerializeField] private Transform _cotainer;
    [SerializeField] private InputDecider _inputDecider;
    
    private IMovementInput _input;
    private Dictionary<CarType, GameObject> _carPrefab = new Dictionary<CarType, GameObject>();
    
    private void Awake()
    {
        _input = _inputDecider.Decide();
        _input.Enable();
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
            spawned.transform.rotation = transform.rotation;
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
            prefab.GetComponentInChildren<MoveController>().Init(_input);
            prefab.GetComponentInChildren<MoveController>().Activate();
        }
    }
}
