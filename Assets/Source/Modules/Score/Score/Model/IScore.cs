using UnityEngine.Events;

public interface IScore
{
    public int Value { get; }
    public event UnityAction Changed;
    public void Add(int value);
    public bool TrySpend(int value);
}
