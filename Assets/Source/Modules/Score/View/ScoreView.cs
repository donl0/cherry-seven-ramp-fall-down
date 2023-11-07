using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : BaseRenderView<String>
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Image _icon;

    [SerializeField] private Sprite _iconTemplate;
    
    public override void Render(string item)
    {
        _icon.sprite = _iconTemplate;
        _score.text = item;
    }
}
