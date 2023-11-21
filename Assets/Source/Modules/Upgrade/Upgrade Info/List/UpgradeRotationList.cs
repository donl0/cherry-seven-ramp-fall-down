using System.Collections.Generic;
using System.Linq;

public class UpgradeRotationList : UpgradeInfoList<RotationUpgradeDS>
{
    private List<RotationUpgradeDS> _rotations = new List<RotationUpgradeDS>()
    {
        new RotationUpgradeDS(CarType.police, 7, 1),
        new RotationUpgradeDS(CarType.police, 8, 2),
        new RotationUpgradeDS(CarType.police, 9, 3),
        new RotationUpgradeDS(CarType.police, 10, 4),
        new RotationUpgradeDS(CarType.police, 11, 5),
        new RotationUpgradeDS(CarType.police, 12, 6),
        new RotationUpgradeDS(CarType.police, 13, 7),
        new RotationUpgradeDS(CarType.police, 14, 8),
        new RotationUpgradeDS(CarType.police, 15, 9),
        new RotationUpgradeDS(CarType.police, 16, 9),
        new RotationUpgradeDS(CarType.police, 17, 10),

        new RotationUpgradeDS(CarType.niisan, 7, 1),
        new RotationUpgradeDS(CarType.niisan, 8, 2),
        new RotationUpgradeDS(CarType.niisan, 9, 3),
        new RotationUpgradeDS(CarType.niisan, 10, 4),
        new RotationUpgradeDS(CarType.niisan, 11, 5),
        new RotationUpgradeDS(CarType.niisan, 12, 6),
        new RotationUpgradeDS(CarType.niisan, 13, 7),
        new RotationUpgradeDS(CarType.niisan, 14, 8),
        new RotationUpgradeDS(CarType.niisan, 15, 9),
        new RotationUpgradeDS(CarType.niisan, 16, 9),
        new RotationUpgradeDS(CarType.niisan, 17, 10),
        
        new RotationUpgradeDS(CarType.cherrySeven, 7, 1),
        new RotationUpgradeDS(CarType.cherrySeven, 8, 2),
        new RotationUpgradeDS(CarType.cherrySeven, 9, 3),
        new RotationUpgradeDS(CarType.cherrySeven, 10, 4),
        new RotationUpgradeDS(CarType.cherrySeven, 11, 5),
        new RotationUpgradeDS(CarType.cherrySeven, 12, 6),
        new RotationUpgradeDS(CarType.cherrySeven, 13, 7),
        new RotationUpgradeDS(CarType.cherrySeven, 14, 8),
        new RotationUpgradeDS(CarType.cherrySeven, 15, 9),
        new RotationUpgradeDS(CarType.cherrySeven, 16, 9),
        new RotationUpgradeDS(CarType.cherrySeven, 17, 10),
    };
    
    public override RotationUpgradeDS GetInfo(CarType car, int level)
    {
        RotationUpgradeDS acceleration = _rotations.FirstOrDefault(a => a.Car == car & a.Level == level);

        return acceleration;
    }
}
