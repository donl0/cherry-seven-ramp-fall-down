using UnityEngine;

public class CarPartCirclePresenter : BaseCirclePresenter<InventoryCarPartsHandler, CarPart>
{
    [SerializeField] private CarPart _carPart;
    [SerializeField] private AddScoreCirclePresenter _ifIsCollectedPresenter;

    private string _saveKey;
    
    private CarPartSaveAssistance _partSaveAssistance;

    protected override void Awake()
    {
        base.Awake();

        _saveKey = _carPart.ToString();
        
        InitSaveAssistance();
        TryEnableAnother(_ifIsCollectedPresenter);
    }

    private void InitSaveAssistance()
    {
        _partSaveAssistance = new CarPartSaveAssistance(_saveKey);
        _partSaveAssistance.Load();
    }

    private bool TryEnableAnother(AddScoreCirclePresenter presenter)
    {
        if (_partSaveAssistance.IsCollected == true)
        {
            DisableSystem();
            ActivateAnother(presenter);

            return false;
        }

        return true;
    }

    private void ActivateAnother(AddScoreCirclePresenter presenter)
    {
        presenter.gameObject.SetActive(true);
        presenter.enabled = true;
    }

    protected override void OnEnter(InventoryCarPartsHandler value)
    {
        base.OnEnter(value);
        _partSaveAssistance.Collect();
        _partSaveAssistance.Save();
    }

    protected override CircleEffector<InventoryCarPartsHandler> InitEffector()
    {
        var effector = new CarPartEffector(_carPart);
        return effector;
    }
}
