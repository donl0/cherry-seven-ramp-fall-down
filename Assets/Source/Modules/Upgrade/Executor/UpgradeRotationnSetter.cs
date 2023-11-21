using UnityEngine;

internal class UpgradeRotationnSetter: UpgradeSetter<UpgradeRotationList, RotationUpgradeDS>
{
    [SerializeField] private CarMover _mover;
    
    public override void Set()
    {
        base.Set();
        
        _mover.SetRotationSpeed(UpgradeDS.Rotation);
    }
}
