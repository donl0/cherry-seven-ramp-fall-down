using UnityEngine;

internal abstract class BaseCircleView<T>: MonoBehaviour
{
    [SerializeField] private ParticleSystem _circle;

    public virtual void Render(T item)
    {
        _circle.Play();
    }

    public abstract void Hide();
}
