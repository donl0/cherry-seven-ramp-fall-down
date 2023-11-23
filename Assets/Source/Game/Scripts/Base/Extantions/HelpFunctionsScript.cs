using System;
using UnityEngine;

//#if UNITY_WEBGL || !UNITY_EDITOR
//using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
//#endif

public class HelpFunctionsScript : MonoBehaviour
{
    [SerializeField] public Transform _resetPostition;
    
    [ContextMenu("Clear Prefs")]
    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
    
    [ContextMenu("Reset Player Position")]
    private void ResetPosition()
    {
        String playerTag = "Player";
        
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        Debug.Log(player.name);
        player.transform.position = _resetPostition.position;
    }
}