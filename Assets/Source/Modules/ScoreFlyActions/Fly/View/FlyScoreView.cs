using TMPro;
using UnityEngine;

public class FlyScoreView : MonoBehaviour, IScoringView
{
    [SerializeField] private TMP_Text _text;

    public void SetScore(string value)
    {
        _text.text = value;
    }

    public void HideScore()
    {
        _text.alpha = 0f;
    }

    public void ShowScore()
    {
        _text.alpha = 1f;
    }
}