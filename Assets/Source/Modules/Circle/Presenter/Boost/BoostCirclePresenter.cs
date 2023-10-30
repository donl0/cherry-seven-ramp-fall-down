using UnityEngine;

public class BoostCirclePresenter : BaseCirclePresenter<Car, InsideCircleViewItemName>
{
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _forse;

    protected override CircleEffector<Car> InitEffector()
    {
        var effector = new CircleBoostEffector(_forse, _forceDirection);
        return effector;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _forceDirection * 5f);
    }
}
