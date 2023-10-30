using System;
using TMPro;
using UnityEngine;

internal class StringCircleView : BaseCircleView<StringColor>
{
    [SerializeField] private TMP_Text _text;
    
    public override void Render(StringColor item)
    {
        base.Render(item);

        _text.text = item.String;
        _text.color = item.Color;
    }
    
    protected override void OnHide()
    {
        float offColor = 0f;
        _text.alpha = offColor;
    }
}
