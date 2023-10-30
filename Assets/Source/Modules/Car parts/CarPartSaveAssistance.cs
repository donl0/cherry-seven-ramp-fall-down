using System;
using UnityEngine;

[Serializable]
public class CarPartSaveAssistance : SavedObject<CarPartSaveAssistance>
{
    [SerializeField] private bool _isCollected;

    public bool IsCollected => _isCollected;

    public CarPartSaveAssistance(string guid) : base(guid)
    {
    }

    public void Collect()
    {
        if (_isCollected == true)
        {
            throw new InvalidOperationException("Trying to collect an already collected CartPartSaveAssistance.");
        }

        _isCollected = true;
    }

    protected override void OnLoad(CarPartSaveAssistance loadedObject)
    {
        _isCollected = loadedObject._isCollected;
    }
}
