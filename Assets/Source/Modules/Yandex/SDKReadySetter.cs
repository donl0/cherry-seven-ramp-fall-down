using Agava.YandexGames;
using UnityEngine;

public class SDKReadySetter : MonoBehaviour
{
    private void Awake()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
                 return;
        #endif
        YandexGamesSdk.GameReady();
    }
}
