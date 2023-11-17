using UnityEngine;
using UnityEngine.Events;

public class JoystickInput : MonoBehaviour, IMovementInput
{
    [SerializeField] private Joystick _joystick;

    private float _vertical;
    private float _horizontal;

    public float Vertical => _vertical;
    public float Horizontal => _horizontal;
    public UnityAction ForwardPressed { get; set; }

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    public void Update()
    {
        _horizontal = _joystick.Direction.x;
        _vertical = _joystick.Direction.y;
    }
    
    public void Enable()
    {
        _joystick.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        _joystick.gameObject.SetActive(false);
        gameObject.SetActive(false);

    }
}
