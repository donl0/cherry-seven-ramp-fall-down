using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeСontrollabilityList : UpgradeInfoList<СontrollabilityUpgradeDS>
{
 private List<СontrollabilityUpgradeDS> _acceleratios = new List<СontrollabilityUpgradeDS>()
    {
        new СontrollabilityUpgradeDS(CarType.police,  25, 40, 3f, 1f, 4f, 0.75f, 1f, 1),

        new СontrollabilityUpgradeDS(CarType.cherrySeven,  65, 20, 0.4f, 1f, 0.5f, 0.75f, 1f, 1),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  60, 45, 0.5f, 1f, 0.52f, 0.8f, 1.1f, 2),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  50, 55, 0.55f, 1f, 0.54f, 0.85f, 1.2f, 3),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  45, 70, 0.6f, 1f, 0.56f, 0.9f, 1.3f, 4),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  35, 120, 0.65f, 1f, 0.58f, 0.95f, 1.35f, 5),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  35, 180, 0.75f, 1f, 0.6f, 1f, 1.4f, 6),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  25, 200, 0.77f, 1f, 0.62f, 1.1f, 1.45f, 7),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  18, 270, 0.8f, 1f, 0.64f, 1.2f, 1.5f, 8),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  17, 330, 0.9f, 1f, 0.7f, 1.4f, 1.7f, 9),
        new СontrollabilityUpgradeDS(CarType.cherrySeven,  15, 400, 1f, 1f, 0.7f, 1.7f, 2f, 10),

        new СontrollabilityUpgradeDS(CarType.niisan,  30, 20, 2f, 1f, 2f, 0.75f, 1f, 1),
        new СontrollabilityUpgradeDS(CarType.niisan,  26, 25, 2f, 4f, 2f, 2.75f, 1.1f, 2),
        new СontrollabilityUpgradeDS(CarType.niisan,  24, 30, 2f, 6f, 2f, 5.75f, 1.2f, 3),
        new СontrollabilityUpgradeDS(CarType.niisan,  22, 35, 2f, 8f, 2f, 7.75f, 1.3f, 4),
        new СontrollabilityUpgradeDS(CarType.niisan,  21, 40, 2f, 9f, 2f, 8.75f, 1.4f, 5),
        new СontrollabilityUpgradeDS(CarType.niisan,  20, 50, 2f, 9.5f, 2f, 8.75f, 1.45f, 6),
        new СontrollabilityUpgradeDS(CarType.niisan,  19, 70, 2f, 9.9f, 2f, 8.9f, 1.5f, 7),
        new СontrollabilityUpgradeDS(CarType.niisan,  18, 80, 2f, 10f, 2f, 9f, 1.6f, 8),
        new СontrollabilityUpgradeDS(CarType.niisan,  17, 90, 2f, 12f, 2f, 11f, 1.8f, 9),
        new СontrollabilityUpgradeDS(CarType.niisan,  16, 100, 2f, 14f, 2f, 12f, 2f, 10),
    };

    public override СontrollabilityUpgradeDS GetInfo(CarType car, int level)
    {
        СontrollabilityUpgradeDS controllability = _acceleratios.FirstOrDefault(a => a.Car == car & a.Level == level);

        if (controllability == null)
            throw new ArgumentNullException(controllability.ToString(), "controllability not found.");

        return controllability;
    }
}
