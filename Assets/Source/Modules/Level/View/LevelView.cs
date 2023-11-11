using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : BaseRenderView<Level>
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _image;

    [SerializeField] private Transform _partsContainer;
    [SerializeField] private Button _enter;
    
    [SerializeField] private LevelInfoList _info;

    [SerializeField] private CarPartsRenderer _partsRenderer;

    public Transform PartsContainer => _partsContainer;
    public Button Enter => _enter;


    public void Init(InventoryCarPartsHandler partsHandler)
    {
        _partsRenderer.Init(_partsContainer, partsHandler);
    }

    public override void Render(Level item)
    {
        LevelInfo info = _info.GetInfo(item);

        _name.text = info.Name.ToString();
        _image.sprite = info.Sprite;

        _partsRenderer.Render(_info.GetInfo(item).PartsOfCar);
    }
}
