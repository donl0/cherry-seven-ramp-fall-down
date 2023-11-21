public class AccelerationUpgradeDS: UpgradeDS
{
    private int _acceleration;

    public int Acceleration => _acceleration;

    public AccelerationUpgradeDS(CarType car, int level, int acceleration): base(car, level)
    {
        _acceleration = acceleration;
    }
}