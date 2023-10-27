using UnityEngine.Events;

public interface IScoreStarter
{
    public UnityAction ScoreStarted { get; set; }
    public UnityAction ScoreEnded { get; set; }
}
