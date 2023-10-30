using UnityEngine;

internal abstract class BaseCircleView<T>: MonoBehaviour
{
    [SerializeField] private ParticleSystem _circle;

    public virtual void Render(T item)
    {
        _circle.Play();
    }

    public void Hide()
    {
        _circle.Stop();
        OnHide();
    }

    protected abstract void OnHide();
}
