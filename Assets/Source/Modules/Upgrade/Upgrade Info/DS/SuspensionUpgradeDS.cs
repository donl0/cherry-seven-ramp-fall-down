public class SuspensionUpgradeDS:UpgradeDS
{
    private int _suspension;

    public int Suspension => _suspension;

    public SuspensionUpgradeDS(CarType car, int suspension, int level) : base(car, level)
    {
        _suspension = suspension;
    }
}