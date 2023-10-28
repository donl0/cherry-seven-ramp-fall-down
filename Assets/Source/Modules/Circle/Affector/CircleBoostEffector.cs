using UnityEngine;

public class CircleBoostEffector: CircleEffector<Car>
{
    private readonly float _force;
    private readonly Vector3 _forceDirection;
    
    public CircleBoostEffector(float force, Vector3 forceDirection)
    {
        _force = force;
        _forceDirection = forceDirection;
    }

    public override void Affect(Car value)
    {
        if (value.TryGetComponent(out Rigidbody carRigidbody))
        {
            carRigidbody.AddForce(_forceDirection * _force, ForceMode.Acceleration);
        }
    }
}
