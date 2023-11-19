using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_WEBGL || !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

[CreateAssetMenu(menuName = "car/car types list/list")]
public class CarTypesListCircularAccess : CarTypesList
{
    [SerializeField] protected List<CarType> Cars;

    public override ReadOnlyCollection<CarType> CarTypes => new ReadOnlyCollection<CarType>(Cars);
    
    public override int CurrentProgress => Cars.Count;
    public override event UnityAction Updated;

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

    public override void Load()
    {
    }

    public override void Save()
    {
    }

    public override void ResetToZero()
    {
    }
}