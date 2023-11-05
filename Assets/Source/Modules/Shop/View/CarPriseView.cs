using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarPriseView: BaseRenderView<CarType>
{
    [SerializeField] private Image _moneyIconField;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Sprite _moneyIcon;

    [SerializeField] private CarPriseList _carPrises;
    
    public override void Render(CarType item)
    {
        _moneyIconField.sprite = _moneyIcon;

        _text.text = _carPrises.GetPrise(item).ToString();
    }
}