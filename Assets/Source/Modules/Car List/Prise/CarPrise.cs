using System;
using UnityEngine;

[Serializable]
internal class CarPrise
{
    [SerializeField] private int _price;
    [SerializeField] private CarType _car;

    public int Prise => _price;
    public CarType Car => _car;
}