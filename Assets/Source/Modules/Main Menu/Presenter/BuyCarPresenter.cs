using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class BuyCarPresenter : BaseMainMenuPresenter
{
    [SerializeField] private CarPriseView _priseViewTemplate;

    [SerializeField] private CarPartsRenderer _carPartsRenderer;
    
    [SerializeField] private Transform _partViewContainer;
    [SerializeField] private Transform _priseViewContainer;

    [SerializeField] private GameObject _generalContainer;
    
    [SerializeField] private OnSkinChangedInteracter _changeListener;

    [SerializeField] private InventoryCarPartsHandler _partsHandler;
    [SerializeField] private OpenedCars _openedCars;
    [SerializeField] private CarPriseList _carPrises;

    [SerializeField] private MainScoreHolder _scoreHolder;

    [SerializeField] private Button _buyButton;

    private CarPriseView _priseView;

    private CarPartWithCarType _carPartWithCarType;

    private CurrentCarHandler _currentCar;
    private CarType _currentShownCar;
    

    private void Awake()
    {
        _currentCar = new CurrentCarHandler();
        _currentCar.Load();
        _openedCars.Load();
        _carPartWithCarType = new CarPartWithCarType();
        InstantiateTemplates();
    }

    protected override void Activate()
    {
        base.Activate();
        _generalContainer.SetActive(true);
        Sub();
        _currentCar.Load();
        Render(_currentCar.Car);
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
        if (_carPartWithCarType.GetParts(car).Count == 0 || _openedCars.CheckIfContains(car))
        {
            _carPartsRenderer.Hide();
        }
        else
        {
            _carPartsRenderer.Show();
            _carPartsRenderer.Render(car);
        }
        
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

    private void InstantiateTemplates()
    {
        _carPartsRenderer.Init(_partViewContainer);

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

        if (CheckInventoryContainsParts(car) == false)
            return false;
        
        if (_scoreHolder.TrySpend(_carPrises.GetPrise(car)) == false)
            return false;

        _openedCars.Add(car);
        _openedCars.Save();
        _currentCar.ChangeCar(car);
        _currentCar.Changed?.Invoke(car);

        return true;
    }

    private bool CheckInventoryContainsParts(CarType car)
    {
        List<CarPart> parts = _carPartWithCarType.GetParts(car);

        foreach (var part in parts)
        {
            if (_partsHandler.TryFound(part) == false)
                return false;
        }

        return true;
    }
}
