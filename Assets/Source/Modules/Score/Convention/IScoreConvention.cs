public interface IScoreConvention
{
    public void ConvertFlyToScore(ref float value);
    public float ConvertFlipToScore(Flip flip);
}
