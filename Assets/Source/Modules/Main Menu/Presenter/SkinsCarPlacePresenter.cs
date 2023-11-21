internal class SkinsCarPlacePresenter: CarListCarPlacePresenter<SkinCarMover>
{
    private IMainMenuPresenter _upgradesPresenter;

    private void Awake()
    {
        _upgradesPresenter = GetComponent<UpgradesPresenter>();
    }

    protected override void Activate()
    {
        base.Activate();
        _upgradesPresenter.TryActivate();
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        _upgradesPresenter.TryDeactivate();
    }
}

