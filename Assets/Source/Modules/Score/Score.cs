using System;
using UnityEngine;

public class Score : MonoBehaviour, IScore
{
    private float _value;
    
    public float Value => _value;

    public void AddScore(float value)
    {
        if (value < 0)
            throw new ArgumentException("Value should be non-negative.");
        
        _value += value;
    }

    public void RemoveScore(float value)
    {
        if (value < 0)
            throw new ArgumentException("Value should be non-negative.");

        if (_value - value < 0)
            _value = 0;
        else
            _value -= value;
    }
}
