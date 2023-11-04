using UnityEngine;
using UnityEngine.Events;

internal class SkinCarMover: CarMenuMover, IMainCarInteracter
{
    public UnityAction<CarType> Interacted { get; set; }

    protected override void MakeNextMovingCarInfo(out GameObject moveObject, out UnityAction startAction, out UnityAction endAction)
    {
        base.MakeNextMovingCarInfo(out moveObject, out startAction, out endAction);
        startAction += () => Interacted?.Invoke(CurrentCar);;
    }
}