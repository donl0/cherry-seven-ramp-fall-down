using TMPro;
using UnityEngine;

public class FlipScoreView : MonoBehaviour, IScoringView
{
    [SerializeField] private TMP_Text _text;
    
    
    private void Awake()
    {
        HideScore();
    }

    public void SetScore(string value)
    {
        _text.text = value;
    }

    public void HideScore()
    {
        float hideValue = 0f;
        _text.alpha = hideValue;
    }

    public void ShowScore()
    {
        float showValue = 1f;
        _text.alpha = showValue;
    }
}
