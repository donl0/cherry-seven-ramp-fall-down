using UnityEngine;

public class BoostRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = -4f;
    
    private Transform _transform;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 rotation = new Vector3(_transform.rotation.eulerAngles.x, _transform.rotation.eulerAngles.y + _rotationSpeed, _transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
