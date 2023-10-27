public class BaseScoreConvention : IScoreConvention
{
    private float _FlyTimeMultiple = 15f;
    
    public void ConvertFlyToScore(ref float value)
    {
        value *= _FlyTimeMultiple;
    }

    public float ConvertFlipToScore(Flip flip)
    {
        return 500f;
    }
}
