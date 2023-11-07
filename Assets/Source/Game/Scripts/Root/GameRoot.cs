using System;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CarBuilder _carBuilder;
    [SerializeField] private SpawnPosition _spawnPosition;

    [Header("Score detector")]
    [SerializeField] private FlyScoreView _flyView;

    [SerializeField] private FlipScoreView _flipScoreView;

    private MoveController _moveController;
    private FollowObject _cameraFollower;
    private FlyScorePresenter _flyScorePresenter;
    private DuringRaceScoreHolder _raceScoreHandler;

    [Header("Finish")] 
    [SerializeField] private FinishFlowControw finish;
    [SerializeField] private List<IntProgress> _progressesToReset;
    
    private void Start()
    {
        ResetProgresses();
        InitCar();
        InitFinish();
    }

    private void InitCar()
    {
        var car = _carBuilder.Build(_spawnPosition.transform.position);
        SetCarValues(car);
        
        _moveController.Activate();
        _cameraFollower.Activate();
        
        IScoreConvention scoreConvention = new BaseScoreConvention();
        
        _flyScorePresenter.Init(_raceScoreHandler, scoreConvention, _flyView, _flipScoreView);
    }

    private void SetCarValues(GameObject car)
    {
        _moveController = Extantions.GetComponentOrThrowNullException<MoveController>(car, nameof(_moveController));
        _cameraFollower = Extantions.GetComponentOrThrowNullException<FollowObject>(car, nameof(_cameraFollower));
        _flyScorePresenter = Extantions.GetComponentOrThrowNullException<FlyScorePresenter>(car, nameof(_flyScorePresenter));
        _raceScoreHandler = Extantions.GetComponentOrThrowNullException<DuringRaceScoreHolder>(car, nameof(_raceScoreHandler));
    }

    private void InitFinish()
    {
        finish.Init(_raceScoreHandler);
        finish.Activate();
    }

    private void ResetProgresses()
    {
        foreach (var progress in _progressesToReset)
        {
            progress.ResetToZero();
        }
    }
}
