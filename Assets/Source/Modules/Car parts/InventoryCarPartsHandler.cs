using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryCarPartsHandler : GUIDObject
{
    [SerializeField] private Inventory<CarPart> _inventory;

    public UnityAction<CarPart> ItemAdded;

    private void Awake()
    {
        _inventory = new Inventory<CarPart>(new List<CarPart>(), GUID);
        _inventory.Load();
    }

    public void Add(CarPart part)
    {
        _inventory.Add(part);
        _inventory.Save();
        ItemAdded?.Invoke(part);
    }

    public bool TryFound(CarPart item) => _inventory.TryFound(item);
}
