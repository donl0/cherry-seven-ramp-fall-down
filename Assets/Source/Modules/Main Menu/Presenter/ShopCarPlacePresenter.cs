using UnityEngine;

internal class ShopCarPlacePresenter: CarListCarPlacePresenter<CarMenuMover>
{
    [SerializeField] private BuyCarPresenter _buyCarPresenter;

    protected override void Activate()
    {
        base.Activate();
        _buyCarPresenter.TryActivate();
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        _buyCarPresenter.TryDeactivate();
    }
}