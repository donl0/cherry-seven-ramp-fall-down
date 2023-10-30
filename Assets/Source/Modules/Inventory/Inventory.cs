using System.Collections.Generic;

public class Inventory<T>: SavedObject<Inventory<T>>
{
    private List<T> _items = new List<T>();
    
    public Inventory(string guid) : base(guid)
    {
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    private void MakeCopy(out List<T> items)
    {
        items = new List<T>(_items);
    }

    protected override void OnLoad(Inventory<T> loadedObject)
    {
        loadedObject.MakeCopy(out _items);
    }
}
