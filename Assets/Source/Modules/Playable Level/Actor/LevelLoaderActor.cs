using System;
using UnityEngine.SceneManagement;

public abstract class LevelLoaderActor<T> : Actor<T>
{
    protected Level _currentLevel;

    protected override void Awake()
    {
        base.Awake();
        SetCurrentLevel();
    }

    private void SetCurrentLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (Enum.TryParse<Level>(currentSceneName, out Level currentLevel))
            _currentLevel = currentLevel;
        else
            throw new ArgumentException($"Scene {currentSceneName} not in enum.");
    }
}