using UnityEngine;
using UnityEngine.UI;

public class CarPartView : BaseRenderView<CarPart>
{
    [SerializeField] private Image _partIcon;
    [SerializeField] private Image _havingIcon;

    [SerializeField] private CarPartItemSpriteList _partWithSprite;

    [SerializeField] private Sprite _partInInventorySprite;
    [SerializeField] private Sprite _partNotInInventorySprite;

    private InventoryCarPartsHandler _partsHandler;

    public void Init(InventoryCarPartsHandler partsHandler)
    {
        _partsHandler = partsHandler;
    }

    public override void Render(CarPart item)
    {
        Sprite partSprite = _partWithSprite.TakePicture(item);
        _partIcon.sprite = partSprite;
        
        if (_partsHandler.TryFound(item) == true)
        {
            _havingIcon.sprite = _partInInventorySprite;
        }
        else
        {
            _havingIcon.sprite = _partNotInInventorySprite;
        }
    }
}