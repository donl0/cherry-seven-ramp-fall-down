using UnityEngine.Events;

public interface IRestartClickable
{
    public UnityAction RestartButtonClicked { get; set; }
}