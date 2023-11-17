using UnityEngine;

[RequireComponent(typeof(ICarMover))]
[RequireComponent(typeof(IMovementInput))]
public class MoveController : MonoBehaviour, IFlowControl
{
    private IMovementInput _input;
    private ICarMover _carMover;
    
    private bool _isActive = false;
    
    private void Awake()
    {
        _carMover = GetComponent<ICarMover>();
    }

    public void Init(IMovementInput input)
    {
        _input = input;
    }

    private void LateUpdate()
    {
        if (_isActive == false)
            return;
        
        float horizontalAffection = _input.Horizontal;
        float verticalAffection = _input.Vertical;
        
        if (verticalAffection != 0)
            _carMover.AffectVertical(verticalAffection);
        
        if (horizontalAffection != 0)
            _carMover.AffectHorizontal(horizontalAffection);
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void DeActivate()
    {
        _isActive = false;
    }
}
