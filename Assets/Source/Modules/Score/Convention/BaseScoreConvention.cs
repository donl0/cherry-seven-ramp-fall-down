public class BaseScoreConvention : IScoreConvention
{
    private float _FlyTimeMultiple = 15f;
    
    public int ConvertFlyToScore(float value)
    {
        value *= _FlyTimeMultiple;
        return (int)value;
    }

    public int ConvertFlipToScore(Flip flip)
    {
        return 500;
    }
}
