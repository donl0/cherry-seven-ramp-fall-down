using UnityEngine.Events;

public interface INextLevelClickable
{
    public UnityAction NextLevelButtonClicked { get; set; }
}