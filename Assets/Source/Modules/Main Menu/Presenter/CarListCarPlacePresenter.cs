using UnityEngine;
using UnityEngine.UI;

internal class CarListCarPlacePresenter<T> : MainMenuCarPlacePresenter where T: ICarMenuMover
{
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;

    private T _mover;

    
    private void Awake()
    {
        _mover = GetComponent<T>();
    }

    private void OnNextButtonClicked()
    {
        _mover.MoveRight();
    }

    private void OnPreviousButtonClicked()
    {
        _mover.MoveLeft();
    }

    private void ActivateButtons()
    {
        _previousButton.gameObject.SetActive(true);
        _nextButton.gameObject.SetActive(true);
    }

    private void DeactivateButtons()
    {
        _previousButton.gameObject.SetActive(false);
        _nextButton.gameObject.SetActive(false);
    }

    private void SubButtons()
    {
        _previousButton.onClick.AddListener(OnPreviousButtonClicked);
        _nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void UnSubButtons()
    {
        _previousButton.onClick.RemoveListener(OnPreviousButtonClicked);
        _nextButton.onClick.RemoveListener(OnNextButtonClicked);
    }

    protected override void Activate()
    {
        base.Activate();
        ActivateButtons();
        SubButtons();
        _mover.Activate();
    }

    protected override void Deactivate()
    {
        base.Deactivate();
        DeactivateButtons();
        UnSubButtons();
        _mover.Hide();
    }
}
