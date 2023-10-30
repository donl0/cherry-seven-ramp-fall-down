using UnityEngine;

internal class DecreaseScoreCirclePresenter : BaseCirclePresenter<DuringRaceScoreHolder, StringColor>
{
    [SerializeField] private int _amount;


    protected override void InitEffector()
    {
        _effector = new DecreaseScoreCircleEffector(_amount);
    }
    
    protected override void UpdateRenderItem(StringColor value)
    {
        value.String = value.String.FixSerializeFieldLineBreak();
        base.UpdateRenderItem(value);
    }
}