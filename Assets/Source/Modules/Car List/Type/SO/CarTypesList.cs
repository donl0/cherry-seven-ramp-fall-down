using System.Collections.ObjectModel;
using UnityEngine;

public abstract class CarTypesList: ScriptableObject
{
    public abstract ReadOnlyCollection<CarType> CarTypes { get; }
}
