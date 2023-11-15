using UnityEngine;

public abstract class BaseItemSpriteList<T, IS> : BaseItemList<T, IS, Sprite> where IS:ItemSprite<T>
{
}
