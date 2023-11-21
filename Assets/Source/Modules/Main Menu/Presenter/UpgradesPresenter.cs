using System;
using UnityEngine;

internal class UpgradesPresenter: BaseMainMenuPresenter
{
    [SerializeField] private GameObject _container;
    
    [SerializeField] private UpgradeView _accelerationView;
    [SerializeField] private UpgradeView _suspensionView;
    [SerializeField] private UpgradeView _rotationView;

    [SerializeField] private SkinCarMover _carMover;
    
    private CurrentCarHandler _currentCar;
    private Levels _levelsHandler;

    private void Awake()
    {
        _currentCar = new CurrentCarHandler();
        _levelsHandler = new Levels();
    }

    private void OnEnable()
    {
        _carMover.Interacted += OnCarChanged;
    }

    private void OnDisable()
    {
        _carMover.Interacted -= OnCarChanged;
    }

    private void OnCarChanged(CarType car)
    {
        SetView(car);
    }

    protected override void Activate()
    {
        base.Activate();
        
        _container.SetActive(true);
        
        _currentCar.Load();
        SetView(_currentCar.Car);
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        _container.SetActive(false);
    }

    private void SetView(CarType car)
    {
        _levelsHandler.Load();

        RenderView(_accelerationView, car, UpgradeType.Acceleration, "Acceleration: ");
        RenderView(_suspensionView, car, UpgradeType.Suspension, "Suspension: ");
        RenderView(_rotationView, car, UpgradeType.Rotation, "Rotation: ");
    }

    private void RenderView(UpgradeView view, CarType car, UpgradeType upgrade, string levelString)
    {
        _levelsHandler.GetViewInfo(car, upgrade, out int level, out int price);
        
        UpgradeViewDS acceleration = new UpgradeViewDS(levelString + level, price.ToString());
        view.Render(acceleration);
    }
}