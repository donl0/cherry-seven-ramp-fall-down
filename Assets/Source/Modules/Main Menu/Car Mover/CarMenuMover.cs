using System.Collections;
using UnityEngine;
using UnityEngine.Events;

internal class CarMenuMover: MonoBehaviour, ICarMenuMover
{
    [SerializeField] private CarTypesListCircularAccess _carTypes;
    [SerializeField] private CurrentCarHandler _progressCarType;
    [SerializeField] private CarPool _pool;

    [SerializeField] private Vector3 _leftPosition;
    [SerializeField] private Vector3 _rightPosition;
    [SerializeField] private Vector3 _middlePosition;
    
    private CarType _currentCar;

    private Coroutine _moveMainCoroutine;
    private Coroutine _moveNextCoroutine;
    
    private void OnEnable()
    {
        _currentCar = _progressCarType.Load();
    }

    public void MoveLeft()
    {
        if ((_moveNextCoroutine != null) || (_moveMainCoroutine != null))
            return;
        if (_carTypes.Lenght < 2) 
            return;

        MoveMainCarLeft();
        
        MakeNextType();
        
        MovingLeft();
    }

    public void MoveRight()
    {
        if ((_moveNextCoroutine != null) || (_moveMainCoroutine != null))
            return;
        if (_carTypes.Lenght < 2) 
            return;

        MoveMainCarRight();
        
        MakePreviousType();
        
        MovingRight();
    }
    
    private void MakeNextType()
    {
        _currentCar = _carTypes.GetNextTypeCircular(_currentCar);
    }

    private void MakePreviousType()
    {
        _currentCar = _carTypes.GetPreviousTypeCircular(_currentCar);
    }

    private void MovingLeft()
    {
        MakeNextMovingCarInfo(out GameObject moveObject, out UnityAction startAction, out UnityAction endAction);
        
        _moveNextCoroutine = StartCoroutine(Moving(moveObject, _middlePosition, _rightPosition, startAction, endAction));
    }

    private void MovingRight()
    {
        MakeNextMovingCarInfo(out GameObject moveObject, out UnityAction startAction, out UnityAction endAction);
        
        _moveNextCoroutine = StartCoroutine(Moving(moveObject, _middlePosition, _leftPosition, startAction,endAction));
    }

    private void MoveMainCarLeft()
    {
        MakeMainCarInfo(out GameObject moveObject, out UnityAction startAction, out UnityAction endAction);
        
        _moveMainCoroutine = StartCoroutine(Moving(moveObject, _leftPosition, _middlePosition, startAction, endAction));
    }

    private void MoveMainCarRight()
    {
        MakeMainCarInfo(out GameObject moveObject, out UnityAction startAction, out UnityAction endAction);
        
        _moveMainCoroutine = StartCoroutine(Moving(moveObject, _rightPosition, _middlePosition, startAction, endAction));
    }

    private void MakeMainCarInfo(out GameObject moveObject,out UnityAction startAction, out UnityAction endAction)
    {
        MakeCurrentMovingCarInfo(out moveObject,out startAction);
        var o = moveObject;
        endAction = () => { DisableObject(o);
            _moveMainCoroutine = null;
        };
    }
    
    private void MakeNextMovingCarInfo(out GameObject moveObject,out UnityAction startAction, out UnityAction endAction)
    {
        MakeCurrentMovingCarInfo(out moveObject,out startAction);
        var o = moveObject;
        endAction = () => { 
            _moveNextCoroutine = null;
            SaveNewCurrentCar(_currentCar);
        };
    }

    private void MakeCurrentMovingCarInfo(out GameObject moveObject, out UnityAction startAction)
    {
        moveObject = _pool.GetObject(_currentCar);
        
        var o = moveObject;
        startAction = () =>
        {
            EnableObject(o);
        };
    }

    private IEnumerator Moving(GameObject moveObject , Vector3 endPosition,Vector3 startPosition, UnityAction startAction ,UnityAction endAction)
    {
        startAction?.Invoke();

        float actionTime = 0.5f;
        float runTime = 0f;
        float setValue = 0f;
        
        while (runTime <= actionTime)
        {
            runTime += Time.deltaTime;
            setValue = runTime / actionTime;
            moveObject.transform.position = Vector3.Lerp(startPosition, endPosition, setValue);

            yield return null;
        }
        
        endAction?.Invoke();
    }

    private void DisableObject(GameObject value)
    {
        value.SetActive(false);
    }
    
    private void EnableObject(GameObject value)
    {
        value.SetActive(true);
    }

    private void SaveNewCurrentCar(CarType car)
    {
        _progressCarType.Save(car); //TO DO: move another responsoble
    }
}
