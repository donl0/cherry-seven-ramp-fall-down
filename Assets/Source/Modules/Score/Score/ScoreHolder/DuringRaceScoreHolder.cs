public class DuringRaceScoreHolder : ScoreHolder<IScore>
{
    protected override void InitScore()
    {
        _score = new Score();
    }

    public void SaveFinalResult()
    {
        SavedObject<IScore> globalScore = new Score();
        globalScore.Load();
        
        globalScore.Merge(_score);
        globalScore.Save();
    }
}
