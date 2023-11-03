using UnityEngine;

public class CurrentCarPlacer: MonoBehaviour, ICurrentCarPlacer
{
    [SerializeField] private CurrentCarHandler _currentCar;
    [SerializeField] private CarPool _pool;

    [SerializeField] private Vector3 _placePosition;

    private GameObject _currentPrefab;
    
    public void Place()
    {
        _currentPrefab = _pool.GetObject(_currentCar.Load());

        _currentPrefab.transform.position = _placePosition;
        _currentPrefab.SetActive(true);
    }

    public void Hide()
    {
        _currentPrefab.SetActive(false);
    }
}
