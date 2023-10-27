using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private MoveController _moveController;
    [SerializeField] private FollowObject _cameraFollower;
    [SerializeField] private FlipDetector _flipDetector;
    [SerializeField] private FlyTimePresenter _flyTimePresenter;

    [Header("View")] 
    [SerializeField] private FlyScoreView _flyScoreView;
    
    private void Start()
    {
        InitCar();
    }

    private void InitCar()
    {
        _moveController.Activate();
        _cameraFollower.Activate();
        
        Score score = new Score();
        IScoreConvention scoreConvention = new BaseScoreConvention();
        
        _flipDetector.Init(score, scoreConvention);
        _flyTimePresenter.Init(score, scoreConvention, _flyScoreView);
    }
}
