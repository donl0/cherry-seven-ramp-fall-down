using UnityEngine;
using UnityEngine.UI;

public class PresenterActivation : MonoBehaviour
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _skinsButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _preferenceButton;

    private IMainMenuPresenter _homePresenter;
    private IMainMenuPresenter _skinsPresenter;
    private IMainMenuPresenter _shopPresenter;
    
    private void Awake()
    {
        _homePresenter = GetComponent<HomeCarPlacePresenter>();
        _skinsPresenter = GetComponent<SkinsCarPlacePresenter>();
        _shopPresenter = GetComponent<ShopCarPlacePresenter>();
        
        _homePresenter.TryActivate();
    }
    
    private void OnEnable()
    {
        _homeButton.onClick.AddListener(OnHomeButtonClicked);
        _skinsButton.onClick.AddListener(OnSkinsButtonClicked);
        _shopButton.onClick.AddListener(OnShopButtonClicked);
        _preferenceButton.onClick.AddListener(OnPreferenceButtonClicked);
    }

    private void OnDisable()
    {
        _homeButton.onClick.RemoveListener(OnHomeButtonClicked);
        _skinsButton.onClick.RemoveListener(OnSkinsButtonClicked);
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
        _preferenceButton.onClick.RemoveListener(OnPreferenceButtonClicked);
    }

    private void OnHomeButtonClicked()
    {
        _skinsPresenter.TryDeactivate();
        _shopPresenter.TryDeactivate();
        _homePresenter.TryActivate();
    }
    
    private void OnSkinsButtonClicked()
    {
        _homePresenter.TryDeactivate();
        _shopPresenter.TryDeactivate();
        _skinsPresenter.TryActivate();
    }

    private void OnShopButtonClicked()
    {
        _homePresenter.TryDeactivate();
        _skinsPresenter.TryDeactivate();
        _shopPresenter.TryActivate();
    }

    private void OnPreferenceButtonClicked()
    {
    }
}