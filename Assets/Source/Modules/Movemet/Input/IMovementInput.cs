using UnityEngine.Events;

public interface IMovementInput
{
    public float Vertical { get;}
    public float Horizontal { get;}

    public UnityAction ForwardPressed { get; set; }
}
