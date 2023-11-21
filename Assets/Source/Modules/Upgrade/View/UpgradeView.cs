using TMPro;
using UnityEngine;

public class UpgradeView : BaseRenderView<UpgradeViewDS>
{
    [SerializeField] private TMP_Text _value;
    [SerializeField] private TMP_Text _price;


    public override void Render(UpgradeViewDS item)
    {
        _value.text = item.Level;
        _price.text = item.Price;
    }
}