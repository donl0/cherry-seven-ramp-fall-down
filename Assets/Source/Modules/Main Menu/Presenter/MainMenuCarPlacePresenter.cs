using UnityEngine;

public abstract class MainMenuCarPlacePresenter: BaseMainMenuPresenter
{
    [SerializeField] private CurrentCarPlacer _placer;

    protected override void Activate()
    {
        base.Activate();
        _placer.Place();
    }
    
    protected override void Deactivate()
    {
        base.Deactivate();
        _placer.Hide();
    }
}