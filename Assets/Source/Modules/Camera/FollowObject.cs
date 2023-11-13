using UnityEngine;

public class FollowObject : MonoBehaviour, IFlowControl
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    
    private bool _isActive = false;
    
    private void Update()
    {
        if (_isActive == false)
            return;
        
        transform.position = _target.position + _offset;
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
