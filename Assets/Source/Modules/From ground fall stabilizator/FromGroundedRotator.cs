using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class FromGroundedRotator : MonoBehaviour
{
    [SerializeField] private float _rotationForce = 0.01f;

    private Rigidbody _rigidbody;

    private Coroutine _rotatingChecking;
    private Coroutine _rotating;
    
    private bool _isGrounded;
    private Transform _playerTransform;

    private float _previousDot = 0f;
    
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
        TryStopRotating();
    }

    private void StartRotate()
    {
        TryStopRotating();

        _rotating = StartCoroutine(TryRotating());
    }

    private IEnumerator TryRotating()
    {
        float waitBeforeCheck = 1f;
        Vector3 upDirection = Vector3.up;
        Vector3 upLocal = _playerTransform.up;

        while (_isGrounded == true)
        {
            float firstDot = Vector3.Dot(upLocal, upDirection);
            yield return new WaitForSeconds(waitBeforeCheck);

            float secondDot = Vector3.Dot(upLocal, upDirection);

            if (firstDot == secondDot)
            {
                break;
            }
            
            yield return null;
        }
        
        while (_isGrounded == true)
        {
            if (IsOverturned() == true)
            {
                Rotate();
            }
            yield return null;
        }

        _rotating = null;
    }

    private void Rotate()
    {
        Vector3 rotationAxis = _playerTransform.forward;
        
        float dot = Vector3.Dot(Vector3.up, _playerTransform.up);

        Quaternion upQuaternion = Quaternion.AngleAxis(90, Vector3.up);
        
        //_playerTransform.rotation = Quaternion.Lerp(_playerTransform.rotation, upQuaternion, _rotationForce * Time.deltaTime);
        _rigidbody.AddTorque(rotationAxis * _rotationForce * Time.deltaTime, ForceMode.VelocityChange);

        if (dot >= 0.72f)
            _rigidbody.angularVelocity = Vector3.zero;
    }

    private bool IsOverturned()
    {
        float overturnValue = 0.75f;
        
        Vector3 upDirection = Vector3.up;
        Vector3 upLocal = _playerTransform.up;

        float dot = Vector3.Dot(upLocal, upDirection);

        // if (_previousDot != dot)
        // {
        //     _previousDot = dot;
        //     return false;
        // }

        _previousDot = dot;
        
        if (dot < (overturnValue))
            return true;

        return false;
    }

    private void TryStopRotating()
    {
        if (_rotating != null)
        {
            StopCoroutine(_rotating);
            _rotating = null;
        }
    }
}
