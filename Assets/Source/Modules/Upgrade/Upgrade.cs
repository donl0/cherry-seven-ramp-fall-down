using System;
using UnityEngine;

[Serializable]
internal class Upgrade
{
    [SerializeField] private CarType _car;
    [SerializeField] private UpgradeType _type;
    [SerializeField] private int _maxLevel;
    [SerializeField] private int _price;
    
    [SerializeField] private int _currentLevel;

    public CarType Car => _car;
    public UpgradeType Type => _type;
    public int MaxLevel => _maxLevel;
    public int Price => _price;
    public int CurrentLevel => _currentLevel;

    public Upgrade(CarType car, UpgradeType type, int price, int currentLevel, int maxLevel)
    {
        _car = car;
        _type = type;
        _price = price;
        _currentLevel = currentLevel;
        _maxLevel = maxLevel;
    }

    public bool TryUpgrade()
    {
        int upgradeValue = 1;
        
        if (_currentLevel < _maxLevel)
        {
            _currentLevel += upgradeValue;
            return true;
        }

        return false;
    }
}