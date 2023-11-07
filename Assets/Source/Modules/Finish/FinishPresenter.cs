using UnityEngine;

internal class FinishPresenter : MonoBehaviour
{
    [SerializeField] private CarTrigger _trigger;
    
    [SerializeField] private IntProgress _frontFlip;
    [SerializeField] private IntProgress _backFlip;
    [SerializeField] private IntProgress _sideFlip;
    [SerializeField] private IntProgress _flyScore;

    private FinishView _view;
    private DuringRaceScoreHolder _score;

    public void Init(DuringRaceScoreHolder score, FinishView view)
    {
        _score = score;
        _view = view;
    }

    private void Start()
    {
        _view.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _trigger.Enter += OnEntered;
    }

    private void OnDisable()
    {
        _trigger.Enter -= OnEntered;
    }

    private void OnEntered(Car arg0)
    {
        _view.gameObject.SetActive(true);
        
        FinishInfo finishInfo = new FinishInfo(_flyScore.CurrentProgress, _frontFlip.CurrentProgress, _backFlip.CurrentProgress, _sideFlip.CurrentProgress, _score.Value);
        
        _view.Render(finishInfo);
        _score.SaveFinalResult();
    }
}