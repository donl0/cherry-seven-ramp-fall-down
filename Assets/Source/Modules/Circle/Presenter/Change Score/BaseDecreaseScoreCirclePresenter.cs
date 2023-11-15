using UnityEngine;

internal class BaseDecreaseScoreCirclePresenter<T> : BaseCirclePresenter<DuringRaceScoreHolder, T>
{
    [SerializeField] private int _amount;
    
    protected override CircleEffector<DuringRaceScoreHolder> InitEffector()
    {
        var effector = new DecreaseScoreCircleEffector(_amount);
        return effector;
    }
}