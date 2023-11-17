using UnityEngine;

internal abstract class BaseAddScoreCirclePresenter<T> : BaseCirclePresenter<DuringRaceScoreHolder, T>
{
    [SerializeField] private int _amount;

    protected override CircleEffector<DuringRaceScoreHolder> InitEffector()
    {
        var effector = new AddScoreCircleEffector(_amount);
        return effector;
    }
}