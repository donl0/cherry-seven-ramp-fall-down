using System.Collections;
using UnityEngine;
using UnityEngine.Events;

internal class FlyScoring : MonoBehaviour, IScoring
{
    private bool _isWork;
    private float _thresholdTimeToApplyScore = 0.5f;
    private float _flyTime;

    private IScorePresenter _presenter;
    private IScoreConvention _scoreConvention;
    
    private Coroutine _scoring;
    
    public void Init(IScorePresenter presenter, IScoreConvention scoreConvention)
    {
        _presenter = presenter;
        _scoreConvention = scoreConvention;
    }

    public void StartScoring()
    {
        _isWork = true;
        OnScoreStarted();
    }

    public void StopScoring()
    {
        _isWork = false;
    }

    public float GetCurrentScore()
    {
        float flyTime = _flyTime;
        _scoreConvention.ConvertFlyToScore(ref flyTime);

        return flyTime;
    }

    private void OnScoreStarted()
    {
        UnityAction endAction = () =>
        {
            SetScoreZero();
            HideScore();
        };
        
        StartScoringAction(endAction);
    }
    
    private void StartScoringAction(UnityAction endAction)
    {
        if (_scoring != null)
        {
            StopCoroutine(_scoring);
        }
        
        _scoring = StartCoroutine(Scoring(endAction));
    }

    private IEnumerator Scoring(UnityAction endAction)
    {
        while (_isWork == true)
        {
            _flyTime += Time.deltaTime;

            if (_flyTime > _thresholdTimeToApplyScore)
            {
                _presenter.SetFlyScoreView(_flyTime);
                _presenter.ShowFlyScoreView();
            }

            yield return null;
        }

        TryAddScore(_flyTime);
        
        _scoring = null;
        endAction?.Invoke();
    }

    private void TryAddScore(float flyTime)
    {
        if (flyTime > _thresholdTimeToApplyScore)
        {
            _presenter.AddFlyScore(_flyTime);
        }
    }

    private void SetScoreZero()
    {
        _flyTime = 0;
    }

    private void HideScore()
    {
        _presenter.HideFlyScoreView();
    }
}
