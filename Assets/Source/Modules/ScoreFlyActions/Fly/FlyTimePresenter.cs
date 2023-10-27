using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IScoreStarter))]
public class FlyTimePresenter : MonoBehaviour
{
    private IScoringView _view;
    private IScore _score;
    private IScoreConvention _scoreConvention;

    private CarScoreStarter _scoreStarter;

    private bool _isFlying;

    private float _flyTime;

    private float _thresholdTimeToApplyScore = 0.5f;
    
    private Coroutine _scoring;

    private void Awake()
    {
        _scoreStarter = GetComponent<CarScoreStarter>();
    }

    private void OnEnable()
    {
        _scoreStarter.ScoreStarted += OnScoreStarted;
        _scoreStarter.ScoreEnded += OnScoreEnded;
    }

    private void OnDisable()
    {
        _scoreStarter.ScoreStarted -= OnScoreStarted;
        _scoreStarter.ScoreEnded -= OnScoreEnded;
    }

    public void Init(IScore score, IScoreConvention scoreConvention, IScoringView view)
    {
        _score = score;
        _scoreConvention = scoreConvention;
        _view = view;
    }

    private void OnScoreStarted()
    {
        _isFlying = true;

        UnityAction endAction = () =>
        {
            SetScoreZero();
            _view.HideScore();
        };
        
        StartScoring(endAction);
    }

    private void OnScoreEnded()
    {
        _isFlying = false;
    }

    private void StartScoring(UnityAction endAction)
    {
        if (_scoring != null)
        {
            StopCoroutine(_scoring);
        }
        
        _scoring = StartCoroutine(Scoring(endAction));
    }

    private IEnumerator Scoring(UnityAction endAction)
    {
        while (_isFlying == true)
        {
            _flyTime += Time.deltaTime;

            if (_flyTime > _thresholdTimeToApplyScore)
            {
                SetViewScore(_flyTime);
                _view.ShowScore();
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
            _scoreConvention.ConvertScore(ref flyTime);
            _score.AddScore(flyTime);
        }
    }

    private void SetViewScore(float flyTime)
    {
        _scoreConvention.ConvertScore(ref flyTime);

        _view.SetScore(ConvertForView(flyTime));
    }

    private void SetScoreZero()
    {
        _flyTime = 0;
    }

    private string ConvertForView(float value)
    {
        string result = ((int)value).ToString();

        return result;
    }
}
