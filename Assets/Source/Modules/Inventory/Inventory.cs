using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory<T>: SavedObject<Inventory<T>>
{
    [SerializeField] private List<T> _items;
    
    public Inventory(List<T> items, string guid) : base(guid)
    {
        _items = items;
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    private List<T> GetCopy()
    {
        return new List<T>(_items);
    }

    protected override void OnLoad(Inventory<T> loadedObject)
    {
        if (loadedObject._items != null)
            _items = loadedObject._items;
    }
}
