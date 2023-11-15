using UnityEngine;

public abstract class ItemGameObjectList<E, IS> : BaseItemList<E, IS, GameObject> where IS:ItemGameObject<E> 
{
}
