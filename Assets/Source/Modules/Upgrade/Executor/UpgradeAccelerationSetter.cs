using UnityEngine;

internal class UpgradeAccelerationSetter: UpgradeSetter<UpgradeAccelerationList, AccelerationUpgradeDS>
{
    [SerializeField] private CarMover _carMover;
    
    public override void Set()
    {
        base.Set();
        
        _carMover.InitEffector(UpgradeDS.Acceleration);
    }
}