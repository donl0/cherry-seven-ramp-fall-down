using UnityEngine;

public class HomePresenter : MainMenuPresenter
{
    [SerializeField] private CurrentCarPlacer _placer;

    public override void Activate()
    {
        base.Activate();
        _placer.Place();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _placer.Hide();
    }
}
