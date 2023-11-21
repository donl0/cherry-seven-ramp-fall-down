using UnityEngine;

public abstract class BaseRenderView<T> : MonoBehaviour
{
    
    public abstract void Render(T item);
}
