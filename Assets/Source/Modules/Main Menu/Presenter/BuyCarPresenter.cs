using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class BuyCarPresenter : BaseMainMenuPresenter
{
    [SerializeField] private CarPartView _partViewTemplate;
    [SerializeField] private CarPriseView _priseViewTemplate;

    [SerializeField] private Transform _partViewContainer;
    [SerializeField] private Transform _priseViewContainer;

    [SerializeField] private GameObject _generalContainer;
    
    [SerializeField] private OnSkinChangedInteracter _changeListener;
    [SerializeField] private CurrentCarHandler _currentCar;

    [SerializeField] private InventoryCarPartsHandler _partsHandler;
    [SerializeField] private OpenedCarListCircularAccess _openedCars;
    [SerializeField] private CarPriseList _carPrises;

    [SerializeField] private MainScoreHolder _scoreHolder;
    
    [SerializeField] private Button _buyButton;
    
    private const int _partsCount = 3;
    
    private readonly List<CarPartView> _partsView = new List<CarPartView>();
    private CarPriseView _priseView;

    private CarPartWithCarType _carPartWithCarType;

    private CarType _currentShownCar;
    

    private void Awake()
    {
        _carPartWithCarType = new CarPartWithCarType();
        InstantiateTemplates();
    }

    protected override void Activate()
    {
        base.Activate();
        _generalContainer.SetActive(true);
        Sub();
        Render(_currentCar.Load());
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        _generalContainer.SetActive(false);
        UnSub();
    }

    private void Sub()
    {
        _changeListener.Changed += OnMainCarChanged;
        _buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void UnSub()
    {
        _changeListener.Changed -= OnMainCarChanged;
        _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
    }

    private void OnMainCarChanged(CarType value)
    {
        _currentShownCar = value;
        Render(value);
    }

    private void Render(CarType car)
    {
        RenderParts(car, out int renderedCount);
        TryDisableNotRendered(renderedCount);

        RenderPrise(car);
    }

    private void RenderPrise(CarType car)
    {
        if (_openedCars.CheckIfContains(car) == true)
        {
            _priseView.SetIsBought();
            return;
        }
        
        _priseView.Render(car);
        _priseView.SetIsNotBought();
    }
    
    private void RenderParts(CarType car, out int renderedCount)
    {
        renderedCount = 0;
        
        List<CarPart> parts = _carPartWithCarType.GetParts(car);

        for (int renderIndex = 0; renderIndex < parts.Count; renderIndex++)
        {
            _partsView[renderIndex].Render(parts[renderIndex]);
            _partsView[renderIndex].gameObject.SetActive(true);
            renderedCount = renderIndex;
            renderedCount += 1;
        }
    }

    private bool TryDisableNotRendered(int renderedCount)
    {
        if (renderedCount < _partsCount)
        {
            for (int count = renderedCount; count < _partsCount; count++)
            {
                _partsView[count].gameObject.SetActive(false);
            }

            return true;
        }

        return false;
    }

    private void InstantiateTemplates()
    {
        for (int spawned = 0; spawned < _partsCount; spawned++)
        {
            var partView = Instantiate(_partViewTemplate, _partViewContainer);
            partView.Init(_partsHandler);
            _partsView.Add(partView);
        }
        
        _priseView = Instantiate(_priseViewTemplate, _priseViewContainer);
    }

    private void OnBuyButtonClicked()
    {
        TryBuy(_currentShownCar);
        Render(_currentShownCar);
    }

    private bool TryBuy(CarType car)
    {
        if (_openedCars.CheckIfContains(car) == true)
            return false;

        if (_scoreHolder.TrySpend(_carPrises.GetPrise(car)) == false)
            return false;
                
        _openedCars.Add(car);
        _currentCar.Changed(car);

        return true;
    }
}
