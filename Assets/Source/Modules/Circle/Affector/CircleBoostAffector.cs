using System;
using UnityEngine;

public class CircleBoostAffector : CircleAffector<Car>
{
    [SerializeField] private float _force = 2000f;
    
    protected override void OnEnterAction(Car value)
    {
        if (value.TryGetComponent(out Rigidbody carRigidbody))
        {
            carRigidbody.AddForce(-transform.right * _force, ForceMode.Acceleration);
        }
    }

    protected override void OnExit(Car value)
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, -transform.right * 5);
    }
}
