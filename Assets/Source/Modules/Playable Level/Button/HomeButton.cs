using UnityEngine.Events;

public class HomeButton : ButtonConnector, IHomeClickable
{
    public UnityAction HomeButtonClicked { get; set; }

    protected override void OnClicked()
    {
        HomeButtonClicked?.Invoke();
    }
}