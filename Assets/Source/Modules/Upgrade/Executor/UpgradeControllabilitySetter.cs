using System.Collections.Generic;
using UnityEngine;

internal class UpgradeControllabilitySetter: UpgradeSetter<UpgradeСontrollabilityList, СontrollabilityUpgradeDS>
{
    [SerializeField] private CarMover _mover;
    [SerializeField] private List<WheelCollider> _wheels;

    public override void Set()
    {
        base.Set();
        
        _mover.SetSteering(UpgradeDS.TurnSteering);
        
        foreach (var wheel in _wheels)
        {
            wheel.mass = UpgradeDS.WheelMass;
            
            var wheelSidewaysFriction = wheel.sidewaysFriction;
            wheelSidewaysFriction.extremumSlip = UpgradeDS.ExtremumSleep;
            wheelSidewaysFriction.extremumValue = UpgradeDS.ExtremumValue;
            wheelSidewaysFriction.asymptoteSlip = UpgradeDS.AsymptoteSleep;
            wheelSidewaysFriction.asymptoteValue = UpgradeDS.AsymptoteValue;
            wheelSidewaysFriction.stiffness = UpgradeDS.Stiffness;

            wheel.sidewaysFriction = wheelSidewaysFriction;
        }
    }
}