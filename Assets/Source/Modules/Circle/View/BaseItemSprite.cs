using System;
using UnityEngine;

[Serializable]
internal abstract class BaseItemSprite<T>
{
    [SerializeField] private T _itemName;
    [SerializeField] private Sprite _sprite;

    public T ItemName => _itemName;
    public Sprite Sprite => _sprite;
}