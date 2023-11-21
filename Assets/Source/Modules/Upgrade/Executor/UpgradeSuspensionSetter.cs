using System.Collections.Generic;
using UnityEngine;

internal class UpgradeSuspensionSetter: UpgradeSetter<UpgradeSuspensionList, SuspensionUpgradeDS>
{
    [SerializeField] private List<WheelCollider> _wheels;
    
    public override void Set()
    {
        base.Set();
        
        foreach (var wheel in _wheels)
        {
            var wheelSuspensionSpring = wheel.suspensionSpring;
            wheelSuspensionSpring.damper = UpgradeDS.Suspension;
            wheel.suspensionSpring = wheelSuspensionSpring;
        }
    }
}