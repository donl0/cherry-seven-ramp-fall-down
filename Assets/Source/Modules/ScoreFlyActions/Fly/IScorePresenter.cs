public interface IScorePresenter
{
    public void SetFlipScoreView(Flip flip);
    public void SetFlyScoreView(float flyTime);
    public void ShowFlyScoreView();
    public void HideFlyScoreView();
    public void ShowFlipScoreView();
    public void HideFlipScoreView();
    public void AddFlipScore(Flip flip);
    public void AddFlyScore(float flyTime);
}