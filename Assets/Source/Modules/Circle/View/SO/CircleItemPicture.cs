using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="ViewItems", menuName = "CircleViewItems", order = 1)]
public class CircleItemPicture : ScriptableObject
{
    [SerializeField] private List<ViewItemSprite> _items = new List<ViewItemSprite>();

    public Sprite TakePicture(CircleViewItem item)
    {
        var sprite = _items.FirstOrDefault(i => i.Item == item)?.Sprite;
        
        return sprite;
    }
}
