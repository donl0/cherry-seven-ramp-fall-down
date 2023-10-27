public class BaseScoreConvention : IScoreConvention
{
    private float _scoreMultiple = 15f;
    
    public void ConvertScore(ref float value)
    {
        value *= _scoreMultiple;
    }
}
