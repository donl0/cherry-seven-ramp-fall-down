using UnityEngine;

public class BoostCirclePresenter : BaseCirclePresenter<Car, CircleViewItem>
{
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _forse;

    protected override void InitEffector()
    {
        _effector = new CircleBoostEffector(_forse, _forceDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _forceDirection * 5f);
    }
}
