using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private MoveController _moveController;
    [SerializeField] private FollowObject _cameraFollower;
    
    [Header("Score detector")]
    [SerializeField] private FlyScorePresenter flyScorePresenter;
    
    
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
        
        //_flipDetector.Init(score, scoreConvention);
        flyScorePresenter.Init(score, scoreConvention);
    }
}
