using UnityEngine;

internal interface IPool<T>
{
    public GameObject GetObject(T value);
}
