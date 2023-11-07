using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Score :SavedObject<Score>, IScore
{
    private const string SaveKey = "MoneyBalance";
    
    [SerializeField] private int _value;
    
    public int Value => _value;

    public event UnityAction Changed;

    public Score() : base(SaveKey)
    {
    }

    public void Add(int value)
    {
        CheckOnNegative(value);

        _value += value;
        Changed?.Invoke();
    }

    public bool TrySpend(int value)
    {
        CheckOnNegative(value);

        if (_value - value < 0)
            return false;
        
        _value -= value;
        
        Changed?.Invoke();
        return true;
    }
    
    public override void Merge(Score mergeWith)
    {
        int mergeValue = mergeWith.Value;

        CheckOnNegative(mergeValue);

        _value += mergeWith.Value;
    }

    private void CheckOnNegative(int value)
    {
        if (value < 0)
            throw new ArgumentException("Value should be non-negative.");
    }

    protected override void OnLoad(Score loadedObject)
    {
        _value = loadedObject.Value;
    }
}
