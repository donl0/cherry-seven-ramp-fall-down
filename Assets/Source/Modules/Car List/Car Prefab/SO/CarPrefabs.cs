using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "car prefabs")]
public class CarPrefabs : ScriptableObject
{
    [SerializeField] private List<CarTypePrefab> _cars;

    public ReadOnlyCollection<CarTypePrefab> Cars => new ReadOnlyCollection<CarTypePrefab>(_cars);
    
    public bool TryGetPrefab(CarType type, out GameObject prefab)
    {
        prefab = _cars.FirstOrDefault(c => c.Type == type).Prefab;

        return prefab != null;
    }
}
