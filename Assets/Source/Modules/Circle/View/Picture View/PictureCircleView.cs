using UnityEngine;
using UnityEngine.UI;

internal class PictureCircleView : BaseCircleView<CircleViewItem>
{
    [SerializeField] private Image _image;
    [SerializeField] private CircleItemPicture _itenPicture;
    
    public override void Render(CircleViewItem item)
    {
        base.Render(item);

        _image.sprite = _itenPicture.TakePicture(item);
    }

    protected override void OnHide()
    {
        float offColor = 0f;

        Color spriteColor = _image.color;
        spriteColor.a = offColor;
        _image.color = spriteColor;
    }
}
