using System;
using UnityEngine;

[Serializable]
public abstract class BaseItem<T, V>
{
    [SerializeField] private T _itemName;
    [SerializeField] private V _view;

    public T ItemName => _itemName;
    public V View => _view;
}
