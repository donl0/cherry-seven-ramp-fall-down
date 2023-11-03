using System;
using UnityEngine;

[Serializable]
public class CarTypePrefab
{
    [SerializeField] private CarType _type;
    [SerializeField] private GameObject _prefab;

    public CarType Type => _type;

    public GameObject Prefab => _prefab;
}
