using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

internal class UpgradesPresenter: BaseMainMenuPresenter
{
    [SerializeField] private GameObject _container;
    
    [SerializeField] private UpgradeView _accelerationView;
    [SerializeField] private UpgradeView _suspensionView;
    [SerializeField] private UpgradeView _rotationView;
    [SerializeField] private UpgradeView _controllabilityView;

    [SerializeField] private SkinCarMover _carMover;

    [SerializeField] private MainScoreHolder _score;

    [SerializeField] private Button _accelerationButton;
    [SerializeField] private Button _suspensionButton;
    [SerializeField] private Button _rotationButton;
    [SerializeField] private Button _controllabilityButton;

    private CurrentCarHandler _currentCar;
    private Levels _levelsHandler;

    private void Awake()
    {
        _currentCar = new CurrentCarHandler();
    }

    private void OnEnable()
    {
        _carMover.Interacted += OnCarChanged;
        _accelerationButton.onClick.AddListener(() => OnUpgradeClicked(UpgradeType.Acceleration));
        _suspensionButton.onClick.AddListener(() => OnUpgradeClicked(UpgradeType.Suspension));
        _rotationButton.onClick.AddListener(() => OnUpgradeClicked(UpgradeType.Rotation));
        _controllabilityButton.onClick.AddListener(() => OnUpgradeClicked(UpgradeType.Controllability));
    }

    private void OnDisable()
    {
        _carMover.Interacted -= OnCarChanged;
        _accelerationButton.onClick.RemoveListener(() => OnUpgradeClicked(UpgradeType.Acceleration));
        _suspensionButton.onClick.RemoveListener(() => OnUpgradeClicked(UpgradeType.Suspension));
        _rotationButton.onClick.RemoveListener(() => OnUpgradeClicked(UpgradeType.Rotation));
        _controllabilityButton.onClick.RemoveListener(() => OnUpgradeClicked(UpgradeType.Controllability));
    }

    private void OnCarChanged(CarType car)
    {
        SetView(car);
    }

    protected override void Activate()
    {
        base.Activate();

        _currentCar.Load();
        _levelsHandler = new Levels();

        SetView(_currentCar.Car);
        
        _container.SetActive(true);
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
        RenderView(_controllabilityView, car, UpgradeType.Controllability, "Controllability: ");
    }

    private void RenderView(UpgradeView view, CarType car, UpgradeType upgrade, string levelString)
    {
        _levelsHandler.GetViewInfo(car, upgrade, out int level, out int price);
        
        UpgradeViewDS acceleration = new UpgradeViewDS(levelString + level, price.ToString());
        view.Render(acceleration);
    }

    private void OnUpgradeClicked(UpgradeType upgrade)
    {
        _levelsHandler.Load();
        _currentCar.Load();

        int price = _levelsHandler.GetPrice(_currentCar.Car, upgrade);
        
        if (_score.IsEnough(price))
        {
            if (_levelsHandler.TryUpgrade(_currentCar.Car, upgrade))
            {
                _score.TrySpend(price);
                _levelsHandler.Save();
                SetView(_currentCar.Car);
            }
        }
    }
}