using System.Collections.ObjectModel;
using UnityEngine;

public abstract class CarTypesList: Progress
{
    public abstract ReadOnlyCollection<CarType> CarTypes { get; }
}
