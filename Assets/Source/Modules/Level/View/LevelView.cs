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

    public Transform PartsContainer => _partsContainer;
    public Button Enter => _enter;
    
    public override void Render(Level item)
    {
        LevelInfo info = _info.GetInfo(item);

        _name.text = info.Name.ToString();
        _image.sprite = info.Sprite;
    }
}
