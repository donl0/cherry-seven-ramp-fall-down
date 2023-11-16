using UnityEngine;

public class MainScoreHolder :ScoreHolder<Score>
{
    [SerializeField] private IntProgress _totalMoneyProgress;

    protected override void OnEnable()
    {
        base.OnEnable();
        _score.Load();
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        _score.Save();
    }
    
    public override void Add(int value)
    {
        base.Add(value);
        _totalMoneyProgress.Add(_score.Value);
        _totalMoneyProgress.Save();
    }

    protected override void InitScore()
    {
        _score = new Score();
    }

    protected override void OnMoneyChanged()
    {
        base.OnMoneyChanged();
        _score.Save();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        _score.Add(0);
    }
}
