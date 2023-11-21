using UnityEngine;

public class TestScore : MonoBehaviour
{
    [SerializeField] private MainScoreHolder _score;

    [ContextMenu("Add money")]
    private void AddScore()
    {
        _score.Add(10000);
    }
}
