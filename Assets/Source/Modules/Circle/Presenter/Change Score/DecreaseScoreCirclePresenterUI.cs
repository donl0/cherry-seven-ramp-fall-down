internal class DecreaseScoreCirclePresenterUI : BaseDecreaseScoreCirclePresenter<StringWithColor>
{
    protected override void UpdateRenderItem(StringWithColor value)
    {
        value.String = value.String.FixSerializeFieldLineBreak();
        base.UpdateRenderItem(value);
    }
}