internal class FinishInfo
{
    private int _flyScore;
    private int _frontFlips;
    private int _backFlips;
    private int _sideFlips;
    private int _finalScore;

    public int FlyScore => _flyScore;
    public int FrontFlips => _frontFlips;
    public int BackFlips => _backFlips;
    public int SideFlips => _sideFlips;
    public int FinalScore => _finalScore;
    
    internal FinishInfo(int flyScore, int frontFlips, int backFlips, int sideFlips, int finalScore)
    {
        _flyScore = flyScore;
        _frontFlips = frontFlips;
        _backFlips = backFlips;
        _sideFlips = sideFlips;
        _finalScore = finalScore;
    }
}
