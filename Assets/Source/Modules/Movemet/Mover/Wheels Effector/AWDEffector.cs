using UnityEngine;

public class AWDEffector : IWheelsEffector
{
    private readonly WheelCollider[] _front;
    private readonly WheelCollider[] _rear;

    private readonly float _maxAngle;
    private readonly float _torque;

    public AWDEffector(WheelCollider[] front, WheelCollider[] rear, float maxAngle, float torque)
    {
        _front = front;
        _rear = rear;
        _maxAngle = maxAngle;
        _torque = torque;
    }

    public void RotateWheels(float value)
    {
        foreach (var wheel in _front)
        {
            wheel.steerAngle = value * _maxAngle;
        }
    }

    public void AccelerateWheels(float value)
    {
        foreach (var wheel in _rear)
        {
            wheel.motorTorque = value * _torque;
        }
        foreach (var wheel in _front)
        {
            wheel.motorTorque = value * _torque;
        }
    }
}
