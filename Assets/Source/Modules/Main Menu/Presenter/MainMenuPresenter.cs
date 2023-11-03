using UnityEngine;

public abstract class MainMenuPresenter: MonoBehaviour, IMainMenuPresenter
{
    public virtual void Activate()
    {
        enabled = true;
    }
    
    public virtual void Deactivate()
    {
        enabled = false;

    }
}
