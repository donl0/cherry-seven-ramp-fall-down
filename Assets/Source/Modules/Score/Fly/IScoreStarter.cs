using UnityEngine.Events;

public interface IScoreStarter
{
    public UnityAction ScoreStarted { get; }
    public UnityAction ScoreEnded { get; }
}
