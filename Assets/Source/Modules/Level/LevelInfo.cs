using System;
using UnityEngine;

[Serializable]
public class LevelInfo
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private CarType _partsOfCar;
    [SerializeField] private Level _level;
    
    public string Name => _name;
    public Sprite Sprite => _sprite;

    public CarType PartsOfCar => _partsOfCar;
    public Level Level => _level;
}