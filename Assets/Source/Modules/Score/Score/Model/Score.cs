using System;
using UnityEngine.Events;

public class Score :SavedObject<IScore>, IScore
{
    private const string SaveKey = "MoneyBalance";

    private int _value;
    
    public int Value => _value;

    public event UnityAction Changed;

    public Score() : base(SaveKey)
    {
    }

    public void Add(int value)
    {
        CheckOnNegative(value);

        _value += value;
    }

    public void Spend(int value)
    {
        CheckOnNegative(value);

        if (_value - value < 0)
            _value = 0;
        else
            _value -= value;
    }

    protected override void OnLoad(IScore loadedObject)
    {
        _value = loadedObject.Value;
    }

    public override void Merge(IScore mergeWith)
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
}
