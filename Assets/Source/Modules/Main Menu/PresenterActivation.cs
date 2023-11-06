using UnityEngine;
using UnityEngine.UI;

public class PresenterActivation : MonoBehaviour
{
    [SerializeField] private Button _homeButton;
    [SerializeField] private Button _skinsButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _preferenceButton;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _levelCloseButton;
    
    private IMainMenuPresenter _homePresenter;
    private IMainMenuPresenter _skinsPresenter;
    private IMainMenuPresenter _shopPresenter;
    private IMainMenuPresenter _levelPresenter;
    private void Awake()
    {
        _homePresenter = GetComponent<HomeCarPlacePresenter>();
        _skinsPresenter = GetComponent<SkinsCarPlacePresenter>();
        _shopPresenter = GetComponent<ShopCarPlacePresenter>();
        _levelPresenter = GetComponent<DatasPresenter>();
        
        _homePresenter.TryActivate();
    }
    
    private void OnEnable()
    {
        _homeButton.onClick.AddListener(OnHomeButtonClicked);
        _skinsButton.onClick.AddListener(OnSkinsButtonClicked);
        _shopButton.onClick.AddListener(OnShopButtonClicked);
        _preferenceButton.onClick.AddListener(OnPreferenceButtonClicked);
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _levelCloseButton.onClick.AddListener(OnLevelCloseClicked);
    }

    private void OnDisable()
    {
        _homeButton.onClick.RemoveListener(OnHomeButtonClicked);
        _skinsButton.onClick.RemoveListener(OnSkinsButtonClicked);
        _shopButton.onClick.RemoveListener(OnShopButtonClicked);
        _preferenceButton.onClick.RemoveListener(OnPreferenceButtonClicked);
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        _levelCloseButton.onClick.RemoveListener(OnLevelCloseClicked);
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

    private void OnPlayButtonClicked()
    {
        _levelPresenter.TryActivate();
    }

    private void OnLevelCloseClicked()
    {
        _levelPresenter.TryDeactivate();
    }
}