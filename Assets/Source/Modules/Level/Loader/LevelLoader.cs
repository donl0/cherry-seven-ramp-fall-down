using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
    private IDataSharer<Level> _sharer;

    private void Awake()
    {
        _sharer = GetComponent<IDataSharer<Level>>();
    }

    private void OnEnable()
    {
        _sharer.ShareData += OnShared;
    }

    private void OnDisable()
    {
        _sharer.ShareData -= OnShared;
    }

    private void OnShared(Level value)
    {
        SceneManager.LoadScene(value.ToString());
    }
}
