using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

internal class FlipScoring : MonoBehaviour, IScoring
{
    [SerializeField] private Transform _car;
    
    private readonly List<Flip> _currentFlips = new List<Flip>();

    private IScorePresenter _presenter;
    private IScoreConvention _scoreConvention;
    
    private bool _isWork;
    
    private float _currentRotationFrontBack = 0;
    private float _windupRotationFrontBack = 0;

    private float _currentRotationSide = 0;
    private float _windupRotationSide = 0;

    public void Init(IScorePresenter presenter, IScoreConvention scoreConvention)
    {
        _presenter = presenter;
        _scoreConvention = scoreConvention;
    }

    public void StartScoring()
    {
        _isWork = true;
    }

    public void StopScoring()
    {
        _currentFlips.Clear();
        _presenter.HideFlipScoreView();
        _isWork = false;
    }

    public float GetCurrentScore()
    {
        float score = 0f;
        
        foreach (var flipScore in _currentFlips)
        {
            score += _scoreConvention.ConvertFlipToScore(flipScore);
        }
        
        return score;
    }

    private void Update()
    {
        if (_isWork == false)
            return;
        
        DetectBackFrontFlip();
        DetectSideFlip();
    }

    private void DetectSideFlip()
    {
        float SideFlips = GetFlipCount(ref _currentRotationSide, ref _windupRotationSide, _car.eulerAngles.y);

        if (SideFlips >= 1f || SideFlips <= -1f)
        {
            AfterDetectFlipAction(Flip.Side, DoBaseValuesSideFlips);
        }        
    }

    private void DetectBackFrontFlip()
    {
        float FrontBackFlips = GetFlipCount(ref _currentRotationFrontBack, ref _windupRotationFrontBack, _car.eulerAngles.z);

        if (FrontBackFlips >=  1)
        {
            AfterDetectFlipAction(Flip.Back, DoBaseValuesFrontBackFlips);
        }
        else if (FrontBackFlips <= -1)
        {
            AfterDetectFlipAction(Flip.Front, DoBaseValuesFrontBackFlips);
        }
    }

    private int GetFlipCount(ref float currentRotation, ref float windupRotation, float checkEulerAnglesAxis)
    {
        float deltaRotation = (currentRotation - checkEulerAnglesAxis);
        
        currentRotation = checkEulerAnglesAxis;
        
        if (deltaRotation >= 300) 
            deltaRotation -= 360;
        
        if (deltaRotation <= -300) 
            deltaRotation += 360;
        
        windupRotation += (deltaRotation);

        float flips = windupRotation / 360;

        return (int)flips;
    }

    private void AfterDetectFlipAction(Flip flip, UnityAction actionToDoBaseValue)
    {
        _currentFlips.Add(flip);
        actionToDoBaseValue?.Invoke();
        _presenter.AddFlipScore(flip);
        _presenter.SetFlipScoreView(flip);
        _presenter.ShowFlipScoreView();
    }

    private void DoBaseValuesFrontBackFlips()
    {
        _currentRotationFrontBack = 0;
        _windupRotationFrontBack = 0;
    }

    private void DoBaseValuesSideFlips()
    {
        _currentRotationSide = 0f;
        _windupRotationSide = 0f;
    }
}
