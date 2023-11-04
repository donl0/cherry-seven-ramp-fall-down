using UnityEngine;

public abstract class MainMenuPresenter: MonoBehaviour, IMainMenuPresenter
{
    [SerializeField] private CurrentCarPlacer _placer;

    private bool _isActive;
    
    public bool TryActivate()
    {
        if (_isActive == true)
            return false;

        Activate();
        return true;
    }

    public bool TryDeactivate()
    {
        if (_isActive == false)
            return false;

        Deactivate();
        return true;
    }

    protected virtual void Activate()
    {
        enabled = true;
        _isActive = true;
        _placer.Place();
    }
    
    protected virtual void Deactivate()
    {
        enabled = false;
        _isActive = false;
        _placer.Hide();
    }
}
