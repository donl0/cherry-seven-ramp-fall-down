public class RotationUpgradeDS : UpgradeDS
{
    private float _rotation;

    public float Rotation => _rotation;

    public RotationUpgradeDS( CarType car, float rotation, int level) : base(car, level)
    {
        _rotation = rotation;
    }
}
