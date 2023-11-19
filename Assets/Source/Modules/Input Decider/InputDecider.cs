using UnityEngine;

public class InputDecider : MonoBehaviour
{
    [SerializeField] private JoystickInput _mobileInput;
    [SerializeField] private PcInput _pcInput;

    public IMovementInput Decide()
    {
        IPlatformDecider platformDecider = new YandexPlatformDecider();
        
        if (platformDecider.Take() == Platform.Mobile)
            return _mobileInput;
        else
            return _pcInput;
    }
}