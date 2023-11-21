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
    private UpgradeListExecutor _upgradeExecutor;
    
    [Header("Finish")] 
    [SerializeField] private FinishFlowControw finish;
    [SerializeField] private List<IntProgress> _progressesToReset;

    [SerializeField] private InputDecider _inputDecider;
    
    private void Start()
    {
        ResetProgresses();
        InitCar();
        InitFinish();
    }

    private void InitCar()
    {
        var car = _carBuilder.Build(_spawnPosition.transform.position);
        GetCarValues(car);

        InitInput();
        
        _moveController.Activate();
        _cameraFollower.Activate();

        InitScore();
        
        _upgradeExecutor.Set();
    }

    private void InitInput()
    {
        IMovementInput input = _inputDecider.Decide();
        input.Enable();
        _moveController.Init(input);
    }

    private void InitScore()
    {
        IScoreConvention scoreConvention = new BaseScoreConvention();
        _flyScorePresenter.Init(_raceScoreHandler, scoreConvention, _flyView, _flipScoreView);
    }

    private void GetCarValues(GameObject car)
    {
        _moveController = Extantions.GetComponentOrThrowNullException<MoveController>(car, nameof(_moveController));
        _cameraFollower = Extantions.GetComponentOrThrowNullException<FollowObject>(car, nameof(_cameraFollower));
        _flyScorePresenter = Extantions.GetComponentOrThrowNullException<FlyScorePresenter>(car, nameof(_flyScorePresenter));
        _raceScoreHandler = Extantions.GetComponentOrThrowNullException<DuringRaceScoreHolder>(car, nameof(_raceScoreHandler));
        _upgradeExecutor =  Extantions.GetComponentOrThrowNullException<UpgradeListExecutor>(car, nameof(_upgradeExecutor));
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
