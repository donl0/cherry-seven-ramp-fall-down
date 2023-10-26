using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private MoveController _moveController;
    [SerializeField] private FollowObject _cameraFollower;
    [SerializeField] private FlipDetector _flipDetector;
    [SerializeField] private FlyTimePresenter _flyTimePresenter;
    
    private void Start()
    {
        InitCar();
    }

    private void InitCar()
    {
        _moveController.Activate();
        _cameraFollower.Activate();
        
        Score score = new Score();
        
        _flipDetector.Init(score);
        _flyTimePresenter.Init(score);
    }
}
