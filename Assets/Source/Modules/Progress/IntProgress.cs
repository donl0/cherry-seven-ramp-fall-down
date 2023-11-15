using UnityEngine;
using UnityEngine.Events;

#if UNITY_WEBGL || !UNITY_EDITOR
    using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

[CreateAssetMenu(fileName = "IntProgress", menuName = "Progress/IntProgress", order = 51)]
public class IntProgress : Progress
{
    private int _currentProgress;

    public override event UnityAction Updated;

    public override int CurrentProgress => _currentProgress;

    public void Add(int value = 1)
    {
        _currentProgress += value;
        Updated?.Invoke();
    }

    public override void Load()
    {
        _currentProgress = PlayerPrefs.GetInt(SaveKey);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(SaveKey, _currentProgress);
    }

    public override void ResetToZero()
    {
        _currentProgress = 0;
        Save();
    }
}
