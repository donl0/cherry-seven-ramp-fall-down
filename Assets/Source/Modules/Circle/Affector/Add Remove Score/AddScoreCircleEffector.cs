public class AddScoreCircleEffector : CircleEffector<DuringRaceScoreHolder>
{
    private int _amount;
    
    public AddScoreCircleEffector(int amount)
    {
        _amount = amount;
    }

    public override void Affect(DuringRaceScoreHolder value)
    {
        value.Add(_amount);
    }
}
