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

internal abstract class GameObjectView<T, V>: BaseCircleView<T> where V:ItemGameObject<T>
{
    [SerializeField] private Transform _container;
    [SerializeField] private BaseItemList<T, V, GameObject> _items;

    private GameObject _view;
    
    public override void Render(T item)
    {
        base.Render(item);

        var createObject = _items.TakeObject(item);

        _view = Instantiate(createObject, _container);
    }

    protected override void OnHide()
    {
        _view.SetActive(false);
    }
}