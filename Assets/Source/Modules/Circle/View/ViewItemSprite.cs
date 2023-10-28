using System;
using UnityEngine;

[Serializable]
public class ViewItemSprite
{
    [SerializeField] private CircleViewItem _item;
    [SerializeField] private Sprite _sprite;
    
    public CircleViewItem Item => _item;
    public Sprite Sprite => _sprite;
}
