using System;
using UnityEngine;
using UnityEngine.Events;

internal class FinishPresenter : MonoBehaviour,  IRestartClickable, IHomeClickable, INextLevelClickable
{
    [SerializeField] private CarTrigger _trigger;
    
    [SerializeField] private IntProgress _frontFlip;
    [SerializeField] private IntProgress _backFlip;
    [SerializeField] private IntProgress _sideFlip;
    [SerializeField] private IntProgress _flyScore;
    
    private FinishView _view;
    private DuringRaceScoreHolder _score;

    public UnityAction HomeButtonClicked { get; set; }
    public UnityAction RestartButtonClicked { get; set; }
    public UnityAction NextLevelButtonClicked { get; set; }

    public void Init(DuringRaceScoreHolder score, FinishView view)
    {
        _score = score;
        _view = view;
        
        _trigger.Enter += OnEntered;
        _view.Home.onClick.AddListener(OnHomeButtonClicked);
        _view.Reload.onClick.AddListener(OnReloadButtonClicked);
        _view.Next.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void Start()
    {
        _view.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _trigger.Enter -= OnEntered;
        _view.Home.onClick.RemoveListener(OnHomeButtonClicked);
        _view.Reload.onClick.RemoveListener(OnReloadButtonClicked);
        _view.Next.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    private void OnEntered(Car arg0)
    {
        _view.gameObject.SetActive(true);
        
        FinishInfo finishInfo = new FinishInfo(_flyScore.CurrentProgress, _frontFlip.CurrentProgress, _backFlip.CurrentProgress, _sideFlip.CurrentProgress, _score.Value);
        
        _view.Render(finishInfo);
        _score.SaveFinalResult();
    }


    private void OnHomeButtonClicked()
    {
        HomeButtonClicked?.Invoke();
    }

    private void OnReloadButtonClicked()
    {
        RestartButtonClicked?.Invoke();
    }

    private void OnNextLevelButtonClicked()
    {
        NextLevelButtonClicked?.Invoke();
    }
}