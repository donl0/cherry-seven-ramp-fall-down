using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal abstract class BaseItemSpriteList<T, IS> : ScriptableObject where IS:BaseItemSprite<T>
{
    [SerializeField] private List<IS> _items;

    public Sprite TakePicture(T itemName)
    {
        var sprite = _items.FirstOrDefault(i => Equals(i.ItemName, itemName)).Sprite;
        //var sprite = _items.FirstOrDefault(i => i.ItemName == itemName).Sprite;
        Debug.Log("sprite: "+sprite);
        foreach (var item in _items)
        {
            Debug.Log(item.ItemName+" compare with: "+itemName);
            Debug.Log(item.Sprite);
            if (Equals(item.ItemName, itemName))
            {
                Debug.Log(" compareD : ");
                
                return item.Sprite;
            }
        }
        return sprite;
    }
}