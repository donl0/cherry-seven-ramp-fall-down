using UnityEngine;

public abstract class BaseCirclePresenter<T, V> : GUIDObject where T:MonoBehaviour
{
    [SerializeField] private BaseCircleView<V> _view;
    [SerializeField] private Trigger<T> _trigger;
    [SerializeField] private V _renderItem;

    private CircleEffector<T> _effector;

    protected virtual void Awake()
    {
        _effector = InitEffector();
        UpdateRenderItem(_renderItem);
        _view.Render(_renderItem);
    }

    private void OnEnable()
    {
        _trigger.Enter += OnEnter;
        _trigger.Exit += OnExit;
    }

    private void OnDisable()
    {
        _trigger.Enter -= OnEnter;
        _trigger.Exit -= OnExit;
    }
    
    protected virtual void OnEnter(T value)
    {
        _effector.Affect(value);
        _view.Hide();
        DisableSystem();
    }

    protected virtual void UpdateRenderItem(V value)
    {
        _renderItem = value;
    }

    protected abstract CircleEffector<T> InitEffector();

    protected virtual void DisableSystem()
    {
        enabled = false;
        _trigger.enabled =false;
        _view = null;
    }

    protected virtual void OnExit(T value) {}
}


