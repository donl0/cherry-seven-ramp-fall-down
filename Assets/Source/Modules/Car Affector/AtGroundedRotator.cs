using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AtGroundedRotator : MonoBehaviour
{
    [SerializeField] private float _rotationForce = 5f;

    private Rigidbody _rigidbody;

    private Coroutine _rotatingChecking;
    private Coroutine _rotating;
    
    private bool _isGrounded;
    private Transform _playerTransform;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;

        StartRotate();
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }

    private void StartRotate()
    {
        if (_rotating != null)
        {
            StopCoroutine(_rotating);
        }

        _rotating = StartCoroutine(TryRotating());
    }

    private IEnumerator TryRotating()
    {
        float waitBeforeCheck = 0.5f;
        
        yield return new WaitForSeconds(waitBeforeCheck);
        
        while (_isGrounded == true)
        {
            if (IsOverturned() == true)
            {
                Rotate();
            }
            yield return null;
        }
    }

    private void Rotate()
    {
        Vector3 rotationAxis = _playerTransform.forward;
        
        float dot = Vector3.Dot(Vector3.up, _playerTransform.up);
        _rigidbody.AddTorque(rotationAxis * _rotationForce * dot);
    }

    private bool IsOverturned()
    {
        Vector3 upDirection = Vector3.up;
        Vector3 upLocal = _playerTransform.up;

        float dot = Vector3.Dot(upLocal, upDirection);

        if (dot < (0))
            return true;

        return false;
    }
}