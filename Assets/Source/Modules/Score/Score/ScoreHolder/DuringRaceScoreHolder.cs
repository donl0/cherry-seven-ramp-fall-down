public class DuringRaceScoreHolder : ScoreHolder<IScore>
{
    protected override void InitScore()
    {
        _score = new Score();
    }

    public void SaveFinalResult()
    {
        SavedObject<Score> globalScore = new Score();
        globalScore.Load();
        
        globalScore.Merge((Score)_score);
        globalScore.Save();
    }
}
