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
    
    public override void AddMoney(int value)
    {
        base.AddMoney(value);
        _totalMoneyProgress.Add(_score.Value);
        _totalMoneyProgress.Save();
    }
    
    public virtual void SpendMoney(int value)
    {
        base.SpendMoney(value);
        _score.Spend(value);
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
}
