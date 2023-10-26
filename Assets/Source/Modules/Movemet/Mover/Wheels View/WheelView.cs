using UnityEngine;

internal class WheelView : IWheelsView
{
    private readonly WheelCollider[] _frontCollider;
    private readonly WheelCollider[] _rearCollider;
    
    private Transform[] _frontView;
    private Transform[] _rearView;

    internal WheelView(Transform[] frontView, Transform[] rearView, WheelCollider[] frontCollider, WheelCollider[] rearCollider)
    {
        _frontView = frontView;
        _rearView = rearView;
        _frontCollider = frontCollider;
        _rearCollider = rearCollider;
    }

    public void Render()
    {
        int wheelRowCount = 2;

        for (int wheelIndex = 0; wheelIndex < wheelRowCount; wheelIndex++)
        {
            SetParams(_frontView[wheelIndex], _frontCollider[wheelIndex]);
            SetParams(_rearView[wheelIndex], _rearCollider[wheelIndex]);
        }
    }

    private void SetParams(Transform wheelView, WheelCollider wheelCollider)
    {
        wheelCollider.GetWorldPose(out var position, out var rotation);
        wheelView.position = position;
        wheelView.rotation = rotation;

    }
}
