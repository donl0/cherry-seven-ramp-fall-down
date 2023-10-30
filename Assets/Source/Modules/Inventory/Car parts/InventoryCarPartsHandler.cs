using UnityEngine.Events;

public class InventoryCarPartsHandler : GUIDObject
{
    private Inventory<CarPart> _inventory;

    public UnityAction<CarPart> ItemAdded;
    
    private void Awake()
    {
        _inventory = new Inventory<CarPart>(GUID);
        _inventory.Load();
    }

    public void Add(CarPart part)
    {
        _inventory.Add(part);
        _inventory.Save();
        ItemAdded?.Invoke(part);
    }
}
