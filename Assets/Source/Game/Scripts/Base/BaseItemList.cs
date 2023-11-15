using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseItemList<T, IS, V> : ScriptableObject where IS:BaseItem<T, V>
{
    [SerializeField] private List<IS> _items;

    public V TakeObject(T itemName)
    {
        var sprite = _items.FirstOrDefault(i => Equals(i.ItemName, itemName)).View;

        foreach (var item in _items)
        {
            if (Equals(item.ItemName, itemName))
            {
                return item.View;
            }
        }
        return sprite;
    }
}