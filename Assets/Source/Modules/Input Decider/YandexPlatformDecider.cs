using Agava.WebUtility;

internal class YandexPlatformDecider: IPlatformDecider
{
    public Platform Take()
    {
        if (Device.IsMobile == true)
            return Platform.Mobile;
        else
            return Platform.PC;
    }
}