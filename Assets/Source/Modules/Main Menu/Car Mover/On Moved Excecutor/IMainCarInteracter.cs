using UnityEngine.Events;

internal interface IMainCarInteracter
{
    public UnityAction<CarType> Interacted { get; set; }
}
