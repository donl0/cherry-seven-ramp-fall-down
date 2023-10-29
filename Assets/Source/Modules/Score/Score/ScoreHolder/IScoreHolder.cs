using UnityEngine.Events;

public interface IScoreHolder
{
    public int Value { get; }
    public event UnityAction<int> BalanceChanged;
    public abstract void Add(int value);
    public abstract void Spend(int value);
}
