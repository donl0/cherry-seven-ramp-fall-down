using System.Collections.Generic;

public abstract class UpgradeInfoList<T>
{
    public abstract T GetInfo(CarType car, int level);
}
