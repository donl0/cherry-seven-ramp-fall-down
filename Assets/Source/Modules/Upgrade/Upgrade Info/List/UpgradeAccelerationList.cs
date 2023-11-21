using System;
using System.Collections.Generic;
using System.Linq;

public class UpgradeAccelerationList : UpgradeInfoList<AccelerationUpgradeDS>
{
    private List<AccelerationUpgradeDS> _acceleratios = new List<AccelerationUpgradeDS>()
    {
        new AccelerationUpgradeDS(CarType.police,  1, 2500),
        new AccelerationUpgradeDS(CarType.police,  2, 2600),
        new AccelerationUpgradeDS(CarType.police,  3, 2650),
        new AccelerationUpgradeDS(CarType.police,  4, 2700),
        new AccelerationUpgradeDS(CarType.police,  5, 2750),
        new AccelerationUpgradeDS(CarType.police,  6, 2800),
        new AccelerationUpgradeDS(CarType.police,  7, 2900),
        new AccelerationUpgradeDS(CarType.police,  8, 3000),
        new AccelerationUpgradeDS(CarType.police, 9, 3100),
        new AccelerationUpgradeDS(CarType.police,  9, 3200),
        new AccelerationUpgradeDS(CarType.police,  10, 3300),

        new AccelerationUpgradeDS(CarType.niisan,  1, 2400),
        new AccelerationUpgradeDS(CarType.niisan,  2, 2450),
        new AccelerationUpgradeDS(CarType.niisan,  3, 2600),
        new AccelerationUpgradeDS(CarType.niisan,  4, 2700),
        new AccelerationUpgradeDS(CarType.niisan,  5, 2900),
        new AccelerationUpgradeDS(CarType.niisan,  6, 3100),
        new AccelerationUpgradeDS(CarType.niisan,  7, 3150),
        new AccelerationUpgradeDS(CarType.niisan,  8, 3180),
        new AccelerationUpgradeDS(CarType.niisan,  9, 3200),
        new AccelerationUpgradeDS(CarType.niisan,  9, 3220),
        new AccelerationUpgradeDS(CarType.niisan,  10, 3250),

        new AccelerationUpgradeDS(CarType.cherrySeven, 1, 3000),
        new AccelerationUpgradeDS(CarType.cherrySeven,  2, 3100),
        new AccelerationUpgradeDS(CarType.cherrySeven,  3, 3150),
        new AccelerationUpgradeDS(CarType.cherrySeven,  4, 3200),
        new AccelerationUpgradeDS(CarType.cherrySeven, 5, 3300),
        new AccelerationUpgradeDS(CarType.cherrySeven,  6, 3400),
        new AccelerationUpgradeDS(CarType.cherrySeven,  7, 3450),
        new AccelerationUpgradeDS(CarType.cherrySeven,  8, 3500),
        new AccelerationUpgradeDS(CarType.cherrySeven,  9, 3600),
        new AccelerationUpgradeDS(CarType.cherrySeven,  9, 3700),
        new AccelerationUpgradeDS(CarType.cherrySeven,  10, 3800),
    };

    public override AccelerationUpgradeDS GetInfo(CarType car, int level)
    {
        AccelerationUpgradeDS acceleration = _acceleratios.FirstOrDefault(a => a.Car == car & a.Level == level);

        if (acceleration == null)
            throw new ArgumentNullException(acceleration.ToString(), "acceleration not found.");

        
        return acceleration;
    }
}