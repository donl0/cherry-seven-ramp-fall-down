using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal abstract class BaseItemSpriteList<T, IS> : ScriptableObject where IS:BaseItemSprite<T>
{
    [SerializeField] private List<IS> _items;

    public Sprite TakePicture(T itemName)
    {
        var sprite = _items.FirstOrDefault(i => Equals(i.ItemName, itemName)).Sprite;

        foreach (var item in _items)
        {
            if (Equals(item.ItemName, itemName))
            {
                return item.Sprite;
            }
        }
        return sprite;
    }
}