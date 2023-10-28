using UnityEngine;

public abstract class BaseCirclePresenter<T, V> : GUIDObject where T:MonoBehaviour
{
    [SerializeField] private BaseCircleView<V> _view;
    [SerializeField] private Trigger<T> _trigger;
    [SerializeField] private V _renderItem;
    
    protected CircleEffector<T> _effector;

    private void Awake()
    {
        InitEffector();
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
    }
    
    protected abstract void InitEffector();
    protected virtual void OnExit(T value) {}
}
