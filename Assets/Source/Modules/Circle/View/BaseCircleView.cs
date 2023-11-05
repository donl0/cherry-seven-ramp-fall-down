using UnityEngine;

internal abstract class BaseCircleView<T>: BaseRenderView<T>
{
    [SerializeField] private ParticleSystem _circle;

    public override void Render(T item)
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
