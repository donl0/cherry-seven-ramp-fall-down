using UnityEngine;
using UnityEngine.UI;

internal abstract class BaseSpriteView<E, IS> : BaseCircleView<E> where IS: BaseItemSprite<E>
{
    [SerializeField] private Image _image;
    [SerializeField] private BaseItemSpriteList<E, IS> _itemSpriteList;
    
    public override void Render(E itemName)
    {
        base.Render(itemName);
        _image.sprite = _itemSpriteList.TakePicture(itemName);
    }

    protected override void OnHide()
    {
        float offColor = 0f;

        Color spriteColor = _image.color;
        spriteColor.a = offColor;
        _image.color = spriteColor;
    }
}
