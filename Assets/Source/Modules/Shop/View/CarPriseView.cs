using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarPriseView: BaseRenderView<CarType>
{
    [SerializeField] private Image _moneyIconField;
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Sprite _moneyIcon;

    [SerializeField] private CarPriseList _carPrises;
    [SerializeField] private List<Image> _boughtIcons;

    public void SetIsBought()
    {
        foreach (var icon in _boughtIcons)
        {
            icon.enabled = true;
        }

        _moneyIconField.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }

    public void SetIsNotBought()
    {
        foreach (var icon in _boughtIcons)
        {
            icon.enabled = false;
        }

        _moneyIconField.gameObject.SetActive(true);
        _text.gameObject.SetActive(true);
    }

    public override void Render(CarType item)
    {
        _moneyIconField.sprite = _moneyIcon;

        _text.text = _carPrises.GetPrise(item).ToString();
    }
}