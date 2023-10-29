public interface IScoring
{
    public void Init(IScorePresenter presenter, IScoreConvention scoreConvention);
    public void StartScoring();
    public void StopScoring();
    public int GetCurrentScore();
}
