using UnityEngine;

public class UpgradeListExecutor : MonoBehaviour
{
    private IUpgradeSetter[] _upgrades;

    private void Awake()
    {
        _upgrades = GetComponentsInChildren<IUpgradeSetter>();
    }

    public void Set()
    {
        foreach (var upgrade in _upgrades)
        {
            upgrade.Set();
        }
    }
}