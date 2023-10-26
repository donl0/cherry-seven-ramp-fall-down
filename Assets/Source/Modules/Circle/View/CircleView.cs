using UnityEngine;

public class CircleView : MonoBehaviour, ICircleView
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
