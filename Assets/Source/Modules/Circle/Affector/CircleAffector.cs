using UnityEngine;

[RequireComponent(typeof(ICircleView))]
[RequireComponent(typeof(Trigger<>))]
public abstract class CircleAffector<T> : MonoBehaviour where T:MonoBehaviour
{
    private ICircleView _view;
    private Trigger<T> _trigger;

    private void Awake()
    {
        _view = GetComponent<ICircleView>();
        _trigger = GetComponent<Trigger<T>>();
    }

    protected void OnEnable()
    {
        _trigger.Enter += OnEnter;
        _trigger.Exit += OnExit;
    }

    protected void OnDisable()
    {
        _trigger.Enter -= OnEnter;
        _trigger.Exit -= OnExit;
    }

    private void OnEnter(T value)
    {
        _view.Hide();
        OnEnterAction(value);
    }

    protected abstract void OnEnterAction(T value);
    protected abstract void OnExit(T value);
}
