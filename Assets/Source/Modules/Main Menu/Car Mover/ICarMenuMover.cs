using UnityEngine;
using UnityEngine.Events;

internal interface ICarMenuMover
{
    public void Activate();
    public void Hide();
    public void MoveLeft();
    public void MoveRight();
}
