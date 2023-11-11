using UnityEngine;

public class BoostCirclePresenter : BaseCirclePresenter<Car, InsideCircleViewItemName>
{
    [SerializeField] private Vector3 _forceDirection = new Vector3(0, 0, 1f);
    [SerializeField] private float _forse = 800f;

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
