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
        _homePresenter = GetComponent<HomePresenter>();
        _skinsPresenter = GetComponent<SkinsPresenter>();
        _shopPresenter = GetComponent<ShopPresenter>();
        
        _homePresenter.Activate();
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
        _skinsPresenter.Deactivate();
        _shopPresenter.Deactivate();
        _homePresenter.Activate();
    }
    
    private void OnSkinsButtonClicked()
    {
        _shopPresenter.Deactivate();
        _skinsPresenter.Activate();
    }

    private void OnShopButtonClicked()
    {
        _shopPresenter.Activate();
        _skinsPresenter.Deactivate();
    }

    private void OnPreferenceButtonClicked()
    {
        _shopPresenter.Deactivate();
        _skinsPresenter.Deactivate();
    }
}