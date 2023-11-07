using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreHolder<Score> _score;
    [SerializeField] private ScoreView _view;

    private void Start()
    {
        _view.Render(_score.Value.ToString());
    }

    private void OnEnable()
    {
        _score.BalanceChanged += OnChanged;
    }

    private void OnDisable()
    {
        _score.BalanceChanged -= OnChanged;
    }

    private void OnChanged(int value)
    {
        _view.Render(value.ToString());
    }
}
