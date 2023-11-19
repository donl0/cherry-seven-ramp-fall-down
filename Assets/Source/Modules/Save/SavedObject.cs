using UnityEngine;

#if UNITY_WEBGL || !UNITY_EDITOR
    using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public abstract class SavedObject<T> where T : class
{

    private readonly string _guid;

    public SavedObject(string guid)
    {
        _guid = guid;
    }

    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this as T);
        PlayerPrefs.SetString(_guid, jsonString);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_guid) == false)
        {
            OnFirstLoad();
            return;
        }

        var jsonString = PlayerPrefs.GetString(_guid);
        var loadedObject = JsonUtility.FromJson(jsonString, typeof(T));

        OnLoad(loadedObject as T);
    }

    public virtual void Merge(T mergeWith)
    {
    }

    protected virtual void OnFirstLoad()
    {
    }

    protected abstract void OnLoad(T loadedObject);
}