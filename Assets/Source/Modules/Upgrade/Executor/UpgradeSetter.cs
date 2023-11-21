using UnityEngine;

internal abstract class UpgradeSetter<UPGRADES, DS>: MonoBehaviour, IUpgradeSetter where UPGRADES: UpgradeInfoList<DS>, new() where DS: UpgradeDS 
{
    [SerializeField] private CarType _car;
    [SerializeField] private UpgradeType _upgrade;

    protected DS UpgradeDS;
    
    public virtual void Set()
    { 
        UPGRADES upgrades = new UPGRADES();
        
        ILevelContainer levels = new Levels();
        ((Levels)levels).Load();
        
        int level = levels.GetLevel(_car, _upgrade);
        
        UpgradeDS = upgrades.GetInfo(_car, level);
    }
}