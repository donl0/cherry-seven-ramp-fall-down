using UnityEngine.Events;

public interface IScoreHolder
{
    public int Value { get; }
    public event UnityAction<int> BalanceChanged;
    public abstract void AddMoney(int value);
    public abstract void SpendMoney(int value);
}
