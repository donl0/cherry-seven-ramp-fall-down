using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(menuName = "Car types list/list")]
public class CarTypesListCircularAccess : CarTypesList
{
    [SerializeField] protected List<CarType> Cars;

    public override ReadOnlyCollection<CarType> CarTypes => new ReadOnlyCollection<CarType>(Cars);

    public int Lenght => Cars.Count;

    public CarType GetNextTypeCircular(CarType current)
    {
        int currentIndex = GetIndex(current);

        int nextIndex = (currentIndex + 1) % Cars.Count;

        return Cars[nextIndex];
    }
    
    public CarType GetPreviousTypeCircular(CarType current)
    {
        int currentIndex = GetIndex(current);

        int previousIndex = (currentIndex - 1 + Cars.Count) % Cars.Count;

        return Cars[previousIndex];
    }

    private int GetIndex(CarType current)
    {
        int currentIndex = Cars.IndexOf(current);

        if (currentIndex == -1)
            throw new InvalidOperationException($"Element doesnt found");

        return currentIndex;
    }
}
