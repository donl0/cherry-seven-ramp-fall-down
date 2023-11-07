using UnityEngine;

public class CurrentCarPlacer: MonoBehaviour, ICurrentCarPlacer
{
    [SerializeField] private CarPool _pool;

    [SerializeField] private Vector3 _placePosition;

    private CurrentCarHandler _currentCar;
    private GameObject _currentPrefab;
    
    public void Place()
    {
        _currentCar = new CurrentCarHandler();
        _currentCar.Load();
        
        _currentPrefab = _pool.GetObject(_currentCar.Car);

        _currentPrefab.transform.position = _placePosition;
        _currentPrefab.SetActive(true);
    }

    public void Hide()
    {
        _currentPrefab.SetActive(false);
    }
}
