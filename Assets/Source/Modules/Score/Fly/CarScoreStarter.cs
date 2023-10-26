using UnityEngine;
using UnityEngine.Events;

public class CarScoreStarter : MonoBehaviour, IScoreStarter
{
    public UnityAction ScoreStarted { get; set; }
    public UnityAction ScoreEnded { get; set; }
    
    private void OnCollisionEnter(Collision other)
    {
        ScoreEnded?.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        ScoreStarted?.Invoke();
    }
}
