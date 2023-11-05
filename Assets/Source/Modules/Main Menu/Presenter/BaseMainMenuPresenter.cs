using UnityEngine;

public abstract class BaseMainMenuPresenter : MonoBehaviour, IMainMenuPresenter
{
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
    }
    
    protected virtual void Deactivate()
    {
        enabled = false;
        _isActive = false;
    }
}