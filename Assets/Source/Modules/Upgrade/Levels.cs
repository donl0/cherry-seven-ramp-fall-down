using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Levels: SavedObject<Levels>, ILevelContainer
{
    private const string _guid = "LEVELSGUID";

    [SerializeField] private List<Upgrade> _upgrades = new List<Upgrade>();

    public Levels() : base(_guid)
    {
    }

    public int GetPrice(CarType car, UpgradeType upgrade)
    {
        var price = _upgrades.FirstOrDefault(u => u.Type == upgrade & u.Car == car).Price;

        return price;
    }

    public bool TryUpgrade(CarType car, UpgradeType upgrade)
    {
        var currentUpgrade = _upgrades.FirstOrDefault(u => u.Car == car & u.Type == upgrade);

        if (currentUpgrade.TryUpgrade() == true)
            return true;

        return false;
    }

    public void GetViewInfo(CarType car, UpgradeType upgrade, out int level, out int price)
    {
        var currentUpgrade = _upgrades.FirstOrDefault(u => u.Car == car & u.Type == upgrade);

        level = currentUpgrade.CurrentLevel;
        price = currentUpgrade.Price;
    }

    public int GetLevel(CarType car, UpgradeType upgrade)
    {
        var level = _upgrades.FirstOrDefault(u => u.Car == car & u.Type == upgrade).CurrentLevel;

        return level;
    }

    protected override void OnFirstLoad()
    {
        SetBase();
        Save();
    }

    protected override void OnLoad(Levels loadedObject)
    {
        _upgrades = loadedObject._upgrades;
    }

    private void SetBase()
    {
        _upgrades.Add(
            new Upgrade(CarType.police, UpgradeType.Acceleration, 100, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.police, UpgradeType.Rotation, 100, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.police, UpgradeType.Suspension, 100, 1, 10));
        
        _upgrades.Add(
            new Upgrade(CarType.niisan, UpgradeType.Acceleration, 1000, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.niisan, UpgradeType.Rotation, 1000, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.niisan, UpgradeType.Suspension, 1000, 1, 10));

        _upgrades.Add(
            new Upgrade(CarType.cherrySeven, UpgradeType.Acceleration, 1000, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.cherrySeven, UpgradeType.Rotation, 1000, 1, 10));
        _upgrades.Add(
            new Upgrade(CarType.cherrySeven, UpgradeType.Suspension, 1000, 1, 10));
    }
}