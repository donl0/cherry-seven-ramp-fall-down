using UnityEngine.SceneManagement;

public class HomeActor: LevelLoaderActor<IHomeClickable>
{
    private void OnEnable()
    {
        Sharer.HomeButtonClicked += OnHomeButtonClicked;
    }

    private void OnDisable()
    {
        Sharer.HomeButtonClicked -= OnHomeButtonClicked;

    }

    private void OnHomeButtonClicked()
    {
        SceneManager.LoadScene(Level.MainMenu.ToString());
    }
}