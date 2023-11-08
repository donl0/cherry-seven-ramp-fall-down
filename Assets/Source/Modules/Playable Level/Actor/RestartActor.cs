using UnityEngine.SceneManagement;

public class RestartActor: LevelLoaderActor<IRestartClickable>
{
    private void OnEnable()
    {
        Sharer.RestartButtonClicked += OnRestartButtonClicked;
    }

    private void OnDisable()
    {
        Sharer.RestartButtonClicked -= OnRestartButtonClicked;
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(_currentLevel.ToString());
    }
}