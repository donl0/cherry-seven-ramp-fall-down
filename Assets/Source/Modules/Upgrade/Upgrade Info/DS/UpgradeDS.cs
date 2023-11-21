public class UpgradeDS
{
    private CarType _car;
    private int _level;

    public CarType Car => _car;
    public int Level => _level;

    public UpgradeDS(CarType car, int level)
    {
        _car = car;
        _level = level;

    }
}