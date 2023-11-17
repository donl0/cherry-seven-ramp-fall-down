using UnityEngine;

internal abstract class BaseCarPartCirclePresenter<T, B> : BaseCirclePresenter<InventoryCarPartsHandler, CarPart> where T:BaseAddScoreCirclePresenter<B>
{
    [SerializeField] private CarPart _carPart;
    [SerializeField] private T ifIsCollectedPresenter;

    private string _saveKey;
    
    private CarPartSaveAssistance _partSaveAssistance;

    protected override void Awake()
    {
        base.Awake();

        _saveKey = _carPart.ToString();
        
        InitSaveAssistance();
        TryEnableAnother(ifIsCollectedPresenter);
    }

    private void InitSaveAssistance()
    {
        _partSaveAssistance = new CarPartSaveAssistance(_saveKey);
        _partSaveAssistance.Load();
    }

    private bool TryEnableAnother(T presenterUI)
    {
        if (_partSaveAssistance.IsCollected == true)
        {
            DisableSystem();
            ActivateAnother(presenterUI);

            return false;
        }

        return true;
    }

    private void ActivateAnother(T presenterUI)
    {
        presenterUI.gameObject.SetActive(true);
        presenterUI.enabled = true;
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