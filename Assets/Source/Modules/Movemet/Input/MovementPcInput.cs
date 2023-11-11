using UnityEngine;
using UnityEngine.Events;

public class MovementPcInput : MonoBehaviour, IMovementInput
{
    private const string _horizontalString = "Horizontal";
    private const string _verticalString = "Vertical";

    private float _vertical;
    private float _horizontal;
    private bool _buttonPressed;
    
    public float Vertical => _vertical;
    public float Horizontal => _horizontal;
    public UnityAction ForwardPressed { get; set; }

    public bool ButtonPressed => _buttonPressed;

    private void Update()
    {
        _vertical = Input.GetAxis(_verticalString);
        _horizontal = Input.GetAxis(_horizontalString);

        _buttonPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S);

        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            ForwardPressed?.Invoke();
        }
    }
}
