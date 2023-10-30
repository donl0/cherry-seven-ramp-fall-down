using UnityEngine;

public class HelpFunctionsScript : MonoBehaviour
{
    [ContextMenu("Clear Prefs")]
    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
