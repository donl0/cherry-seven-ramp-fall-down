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

        TryRoundToOne(ref _vertical);
        TryRoundToZero(ref _horizontal);
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

    private bool TryRoundToOne(ref float value)
    {
        float range = 0.03f;
        float target = 1f;
        return TryRoundToTarget(ref value, target, range);
    }

    private bool TryRoundToZero(ref float value)
    {
        float range = 0.11f;
        float target = 0;
        return TryRoundToTarget(ref value, target, range);
    }
    
    private bool TryRoundToTarget(ref float value, float target, float range)
    {
        float lowerBound = target - range;
        float upperBound = target + range;

        if (value >= lowerBound && value <= upperBound)
        {
            value = target;
            return true;
        }
        
        return false;
    }
}
