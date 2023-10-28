using UnityEngine;

public abstract class CircleEffector<T> where T:MonoBehaviour
{
    public abstract void Affect(T value);
}
