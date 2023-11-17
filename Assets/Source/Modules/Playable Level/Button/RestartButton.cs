using UnityEngine.Events;

public class RestartButton : ButtonConnector, IRestartClickable
{
    public UnityAction RestartButtonClicked { get; set; }

    protected override void OnClicked()
    {
        RestartButtonClicked?.Invoke();
    }
}