using UnityEngine.SceneManagement;

public class NextLevelActor: LevelLoaderActor<INextLevelClickable>
{
    private void OnEnable()
    {
        Sharer.NextLevelButtonClicked += OnLevelButtonClicked;
    }

    private void OnDisable()
    {
        Sharer.NextLevelButtonClicked -= OnLevelButtonClicked;
    }

    private void OnLevelButtonClicked()
    {
        if (_currentLevel.TryGetNextEnumValue(out Level nextLevel))
        {
            SceneManager.LoadScene(nextLevel.ToString());
        }
    }
}