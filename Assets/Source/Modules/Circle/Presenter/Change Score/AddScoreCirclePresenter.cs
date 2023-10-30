using UnityEngine;

internal class AddScoreCirclePresenter : BaseCirclePresenter<DuringRaceScoreHolder, StringColor>
{
    [SerializeField] private int _amount;

    protected override CircleEffector<DuringRaceScoreHolder> InitEffector()
    {
        var effector = new AddScoreCircleEffector(_amount);
        return effector;
    }

    protected override void UpdateRenderItem(StringColor value)
    {
        value.String = value.String.FixSerializeFieldLineBreak();
        base.UpdateRenderItem(value);
    }
}
