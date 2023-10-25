using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private MoveController _moveController;
    [SerializeField] private FollowObject _cameraFollower;

    private void Start()
    {
        _moveController.Activate();
        _cameraFollower.Activate();
    }
}
