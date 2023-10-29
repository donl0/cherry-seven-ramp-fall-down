using System.Collections.Generic;
using UnityEngine;

public class FlyScorePresenter : MonoBehaviour, IScorePresenter
{
    [SerializeField] private CarScoreStarter _scoreStarter;
    [SerializeField] private FlyScoreView _flyView;
    [SerializeField] private FlipScoreView _flipScoreView;

    private readonly List<Flip> _currentRenderFlips = new List<Flip>();

    private IScoring _flyScoring;
    private IScoring _flipScoring;

    private IScoreHolder _score;
    private IScoreConvention _scoreConvention;


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

    private void Awake()
    {
        _flyScoring = GetComponent<FlyScoring>();
        _flipScoring = GetComponent<FlipScoring>();
    }

    public void Init(IScoreHolder score, IScoreConvention scoreConvention)
    {
        _score = score;
        _scoreConvention = scoreConvention;
        _flyScoring.Init(this, _scoreConvention);
        _flipScoring.Init(this, _scoreConvention);
    }

    private void OnScoreStarted()
    {
        EnableScoring();
    }

    private void OnScoreEnded()
    {
        AddFinalScore();
        DisableScoring();
    }

    private void EnableScoring()
    {
        _flyScoring.StartScoring();
        _flipScoring.StartScoring();
    }

    private void DisableScoring()
    {
        _flyScoring.StopScoring();
        _flipScoring.StopScoring();
    }

    private void AddFinalScore()
    {
        _score.Add(_flipScoring.GetCurrentScore());
        _score.Add(_flipScoring.GetCurrentScore());
    }

    private string ConvertForView(float value)
    {
        string result = ((int)value).ToString();

        return result;
    }

    public void SetFlipScoreView(Flip flip)
    {
        string render = GetFlipRenderString(flip);
        
        _flipScoreView.SetScore(render);
    }

    public void SetFlyScoreView(float flyTime)
    {
        int score = _scoreConvention.ConvertFlyToScore(flyTime);

        _flyView.SetScore(ConvertForView(score));
    }

    public void ShowFlyScoreView()
    {
        _flyView.ShowScore();
    }

    public void HideFlyScoreView()
    {
        _flyView.HideScore();
    }

    public void ShowFlipScoreView()
    {
        _flipScoreView.ShowScore();
    }

    public void HideFlipScoreView()
    {
        _flipScoreView.HideScore();
        _currentRenderFlips.Clear();
    }

    public void AddFlipScore(Flip flip)
    {
        int score = _scoreConvention.ConvertFlipToScore(flip);
        _score.Add(score);
    }

    public void AddFlyScore(float flyTime)
    {
        int score = _scoreConvention.ConvertFlyToScore(flyTime);

        _score.Add(score);
    }

    private string GetFlipRenderString(Flip flip)
    {
        if (_currentRenderFlips.Contains(flip) == false)
        {
            _currentRenderFlips.Add(flip);
        }

        float score = 0;
        string renderString = "";

        foreach (var flipType in _currentRenderFlips)
        {
            renderString += flipType.ToString() + "\n";
        }

        score = _flipScoring.GetCurrentScore();
        
        renderString += "\n" + ((int) score).ToString();
        
        return renderString;
    }
}