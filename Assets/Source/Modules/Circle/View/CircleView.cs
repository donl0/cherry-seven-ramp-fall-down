using UnityEngine;

internal class CircleView : MonoBehaviour, ICircleView
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
