using System;
using UnityEngine;

internal class TwoBackEffector : IWheelsEffector
{
    private readonly WheelCollider[] _front;
    private readonly WheelCollider[] _rear;

    private readonly float _torque;
    
    private float _steeringAngle;

    public TwoBackEffector(WheelCollider[] front, WheelCollider[] rear, float steeringAngle, float torque)
    {
        _front = front;
        _rear = rear;
        _steeringAngle = steeringAngle;
        _torque = torque;
    }

    public void RotateWheels(float value)
    {
        foreach (var wheel in _front)
        {
            wheel.steerAngle = value * _steeringAngle;
        }
    }

    public void AccelerateWheels(float value)
    {
        foreach (var wheel in _front)
        {
            wheel.motorTorque = value * _torque;
        }
    }
    
    public void SetSteering(float value)
    {
        if (value <= 0)
            throw new ArgumentException("value <= 0", nameof(value));

        _steeringAngle = value;
    }
}