using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(IScoreStarter))]
public class FlyTimePresenter : MonoBehaviour, IInittable<Score>
{
    private Score _score;
    
    private CarScoreStarter _scoreStarter;
    
    private bool _isFlying;
    private float _flyTime;

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

    private void OnScoreStarted()
    {
        _isFlying = true;
        StartScoring(SetScoreZero);
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
            SetScore(_flyTime);
            
            yield return null;
        }

        _scoring = null;
        endAction?.Invoke();
    }

    private void SetScore(float flyTime)
    {
        //TO DO: update view and model
    }

    private void SetScoreZero()
    {
        _flyTime = 0;
    }

    public void Init(Score score)
    {
        _score = score;
    }
}
