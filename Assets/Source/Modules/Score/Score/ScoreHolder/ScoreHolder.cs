using UnityEngine;
using UnityEngine.Events;

public abstract class ScoreHolder<T> :MonoBehaviour, IScoreHolder where T:IScore
{
    protected T _score;

    public int Value { get; }
    
    public event UnityAction<int> BalanceChanged;

    protected void Awake()
    {
        InitScore();
    }

    protected virtual void OnEnable()
    {
        _score.Changed += OnMoneyChanged;
    }
    
    protected virtual void OnDisable()
    {
        _score.Changed -= OnMoneyChanged;
    }
    
    public virtual void Add(int value)
    {
        _score.Add(value);
    }

    public virtual void Spend(int value)
    {
        throw new System.NotImplementedException();
    }

    protected abstract void InitScore();
    
    protected virtual void OnMoneyChanged()
    {
        BalanceChanged?.Invoke(_score.Value);
    }
}
