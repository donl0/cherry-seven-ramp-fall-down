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
        _flyScore.text = item.FlyScore.ToString();
        _frontFlips.text = item.FrontFlips.ToString();
        _backFlips.text = item.BackFlips.ToString();
        _sideFlips.text = item.SideFlips.ToString();
        _finalResult.text = item.FinalScore.ToString();
    }
}
