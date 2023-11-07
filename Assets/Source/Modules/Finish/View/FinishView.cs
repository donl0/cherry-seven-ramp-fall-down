using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class FinishView : BaseRenderView<FinishInfo>
{
    [SerializeField] private TMP_Text _flyScore;
    [SerializeField] private TMP_Text _frontFlips;
    [SerializeField] private TMP_Text _backFlips;
    [SerializeField] private TMP_Text _sideFlips;
    [SerializeField] private TMP_Text _finalResult;

    [SerializeField] private Button _reload;
    [SerializeField] private Button _home;
    [SerializeField] private Button _next;

    public Button Reload => _reload;
    public Button Home => _home;
    public Button Next => _next;
    
    public override void Render(FinishInfo item)
    {
        string flyScore = "Fly Score: " + item.FlyScore.ToString();
        string frontFlips = "Front Flips:" + item.FrontFlips.ToString();
        string backFlips = "Back Flips:" + item.BackFlips.ToString();
        string sideFlips = "Side Flips:" + item.SideFlips.ToString();
        string finalResult = "Final Result:" + item.FinalScore.ToString();

        _flyScore.text = flyScore;
        _frontFlips.text = frontFlips;
        _backFlips.text = backFlips;
        _sideFlips.text = sideFlips;
        _finalResult.text = finalResult;
    }
}
