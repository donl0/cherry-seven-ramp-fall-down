using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonConnector : MonoBehaviour
{
    [SerializeField] private Button _button;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    protected abstract void OnClicked();
}