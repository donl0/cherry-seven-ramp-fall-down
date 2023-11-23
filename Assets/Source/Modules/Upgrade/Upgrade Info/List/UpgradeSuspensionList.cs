using System.Collections.Generic;
using System.Linq;

public class UpgradeSuspensionList : UpgradeInfoList<SuspensionUpgradeDS>
{
    private List<SuspensionUpgradeDS> _acceleratios = new List<SuspensionUpgradeDS>()
    {
        new SuspensionUpgradeDS(CarType.police, 100, 1),
        new SuspensionUpgradeDS(CarType.police, 300, 2),
        new SuspensionUpgradeDS(CarType.police, 500, 3),
        new SuspensionUpgradeDS(CarType.police, 900, 4),
        new SuspensionUpgradeDS(CarType.police, 1200, 5),
        new SuspensionUpgradeDS(CarType.police, 1800, 6),
        new SuspensionUpgradeDS(CarType.police, 2400, 7),
        new SuspensionUpgradeDS(CarType.police, 3000, 8),
        new SuspensionUpgradeDS(CarType.police, 3700, 9),
        new SuspensionUpgradeDS(CarType.police, 4000, 9),
        new SuspensionUpgradeDS(CarType.police, 4500, 10),

        new SuspensionUpgradeDS(CarType.niisan, 100, 1),
        new SuspensionUpgradeDS(CarType.niisan, 300, 2),
        new SuspensionUpgradeDS(CarType.niisan, 500, 3),
        new SuspensionUpgradeDS(CarType.niisan, 900, 4),
        new SuspensionUpgradeDS(CarType.niisan, 1200, 5),
        new SuspensionUpgradeDS(CarType.niisan, 1800, 6),
        new SuspensionUpgradeDS(CarType.niisan, 2400, 7),
        new SuspensionUpgradeDS(CarType.niisan, 4500, 8),
        new SuspensionUpgradeDS(CarType.niisan, 5000, 9),
        new SuspensionUpgradeDS(CarType.niisan, 7000, 9),
        new SuspensionUpgradeDS(CarType.niisan, 12000, 10),
        
        new SuspensionUpgradeDS(CarType.cherrySeven, 100, 1),
        new SuspensionUpgradeDS(CarType.cherrySeven, 300, 2),
        new SuspensionUpgradeDS(CarType.cherrySeven, 500, 3),
        new SuspensionUpgradeDS(CarType.cherrySeven, 900, 4),
        new SuspensionUpgradeDS(CarType.cherrySeven, 1200, 5),
        new SuspensionUpgradeDS(CarType.cherrySeven, 1800, 6),
        new SuspensionUpgradeDS(CarType.cherrySeven, 2400, 7),
        new SuspensionUpgradeDS(CarType.cherrySeven, 3000, 8),
        new SuspensionUpgradeDS(CarType.cherrySeven, 3700, 9),
        new SuspensionUpgradeDS(CarType.cherrySeven, 4000, 9),
        new SuspensionUpgradeDS(CarType.cherrySeven, 4500, 10),
    };

    public override SuspensionUpgradeDS GetInfo(CarType car, int level)
    {
        SuspensionUpgradeDS acceleration = _acceleratios.FirstOrDefault(a => a.Car == car & a.Level == level);

        return acceleration;
    }
}