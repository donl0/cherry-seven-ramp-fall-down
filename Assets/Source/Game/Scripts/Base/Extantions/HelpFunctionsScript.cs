using UnityEngine;

//#if UNITY_WEBGL || !UNITY_EDITOR
//using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
//#endif

public class HelpFunctionsScript : MonoBehaviour
{
    [ContextMenu("Clear Prefs")]
    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}