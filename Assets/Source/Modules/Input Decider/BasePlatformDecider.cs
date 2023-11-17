using Agava.YandexGames;
using UnityEngine;
using UnityEngine.iOS;

internal class BasePlatformDecider : IPlatformDecider
{
    public Platform Take()
    {
        if (Application.platform == RuntimePlatform.Android)
            return Platform.Mobile;
        else
            return Platform.PC;
    }
}

