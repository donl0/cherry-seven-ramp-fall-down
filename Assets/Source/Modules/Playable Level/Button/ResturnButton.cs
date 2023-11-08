using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResturnButton : MonoBehaviour, IRestartClickable
{
    [SerializeField] private Button _button;
    
    public UnityAction RestartButtonClicked { get; set; }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        RestartButtonClicked?.Invoke();
    }
}
