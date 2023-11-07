using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlowControw: MonoBehaviour ,IFlowControl
{
    [SerializeField] private FinishPosition _position;
    [SerializeField] private FinishPresenter _presenterTemplate;
    [SerializeField] private FinishView _finishView;

    private DuringRaceScoreHolder _score;
    
    public void Init(DuringRaceScoreHolder score)
    {
        _score = score;
    }

    public void Activate()
    {
        FinishPresenter presenter =  Instantiate(_presenterTemplate, _position.transform);
        presenter.Init(_score, _finishView);
    }

    public void DeActivate()
    {
    }
}
