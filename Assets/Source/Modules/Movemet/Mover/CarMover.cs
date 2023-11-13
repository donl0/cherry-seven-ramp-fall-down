using System;
using UnityEngine;

internal class CarMover : MonoBehaviour, ICarMover
{
    [SerializeField] private WheelCollider[] _frontWheels;
    [SerializeField] private WheelCollider[] _rearWheels;

    [SerializeField] private Transform[] _frontWheelsView;
    [SerializeField] private Transform[] _rearWheelsView;
    
    [SerializeField] private Rigidbody _car;

    [Header("Physics")]
    [SerializeField] private Transform _centreOfMass;

    [SerializeField] private float _torque;
    [SerializeField] private float _maxAngle;

    [SerializeField] private float _rotationSpeed = 10f;

    [SerializeField] private LayerMask _MoveMask;
    
    [SerializeField] private float _lerpRotationSpeed = 2f;
    [SerializeField] private float _radiusNotFlip = 4f;

    private WheelView _wheelView;
    private IWheelsEffector _wheelsEffector;
    
    private void Awake()
    {
        InitEffector();
        InitView();
        TrySetCentreOfMass();
        InitPreference();
    }

    private void Update()
    {
        _wheelView.Render();
    }

    public void AffectHorizontal(float value)
    {
        if (CheckIfCollision())
        {
            _wheelsEffector.RotateWheels(value);
        }
        else
        {
            RotateCarLerp(new Vector3(0f, _rotationSpeed * value, 0f));
        }
    }

    public void AffectVertical(float value)
    {
        if (CheckIfCollision())
        {
            _wheelsEffector.AccelerateWheels(value);
        }
        else
        {
            RotateCarLerp(new Vector3(_rotationSpeed * value, 0f, 0f));
        }
    }

    private void RotateCarLerp(Vector3 lerpTo)
    {
        _car.angularVelocity = Vector3.Lerp(_car.angularVelocity, lerpTo, _lerpRotationSpeed * Time.deltaTime);
    }
    
    private bool CheckIfCollision()
    {
        Collider[] colliders = Physics.OverlapSphere(_car.transform.position, _radiusNotFlip, _MoveMask);

        if (colliders.Length > 0)
            return true;
        
        return false;
    }

    private void InitEffector()
    {
        _wheelsEffector = new AWDEffector(_frontWheels, _rearWheels, _maxAngle, _torque);
    }

    private void InitView()
    {
        _wheelView = new WheelView(_frontWheelsView, _rearWheelsView, _frontWheels, _rearWheels);
    }

    private void InitPreference()
    {
        float maxAngularVelocity = 1000f;
        _car.maxAngularVelocity = maxAngularVelocity;
    }

    private bool TrySetCentreOfMass()
    {
        if (_centreOfMass != null)
        {
            _car.centerOfMass = _centreOfMass.localPosition;
            return true;
        }

        return false;
    }
}
