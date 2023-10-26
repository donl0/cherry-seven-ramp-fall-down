using UnityEngine;
using UnityEngine.Events;

public class FlipDetector : MonoBehaviour, IInittable<Score>
{
    private Score _score;
    
    private Transform _car;
    
    private float _currentRotationFrontBack = 0;
    private float _windupRotationFrontBack = 0;

    private float _currentRotationSide = 0;
    private float _windupRotationSide = 0;

    public UnityAction BackFlipped;
    public UnityAction FrontFlipped;
    public UnityAction SideFlipped;
    
    private void Awake()
    {
        _car = GetComponent<Transform>();
    }

    private void Update()
    {
        DetectBackFrontFlip();
        DetectSideFlip();
    }

    private void DetectSideFlip()
    {
        float SideFlips = GetFlipCount(ref _currentRotationSide, ref _windupRotationSide, _car.eulerAngles.y);

        if (SideFlips >= 1f || SideFlips <= -1f)
        {
            DoBaseValuesSideFlips();
            SideFlipped?.Invoke();
        }        
    }

    private void DetectBackFrontFlip()
    {
        float FrontBackFlips = GetFlipCount(ref _currentRotationFrontBack, ref _windupRotationFrontBack, _car.eulerAngles.z);

        if (FrontBackFlips >=  1)
        {
            DoBaseValuesFrontBackFlips();
            BackFlipped?.Invoke();
        }
        else if (FrontBackFlips <= -1)
        {
            DoBaseValuesFrontBackFlips();
            FrontFlipped?.Invoke();
        }
    }

    private int GetFlipCount(ref float currentRotation, ref float windupRotation, float checkEulerAnglesAxis)
    {
        float deltaRotation = (currentRotation - checkEulerAnglesAxis);
        
        currentRotation = checkEulerAnglesAxis;
        
        if (deltaRotation >= 300) 
            deltaRotation -= 360;
        
        if (deltaRotation <= -300) 
            deltaRotation += 360;
        
        windupRotation += (deltaRotation);

        float flips = windupRotation / 360;

        return (int)flips;
    }

    private void DoBaseValuesFrontBackFlips()
    {
        _currentRotationFrontBack = 0;
        _windupRotationFrontBack = 0;
    }
    
    private void DoBaseValuesSideFlips()
    {
        _currentRotationSide = 0f;
        _windupRotationSide = 0f;
    }

    public void Init(Score score)
    {
        _score = score;
    }
}
