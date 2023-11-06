using UnityEngine.Events;

public interface IDataSharer<T>
{
    public UnityAction<T> ShareData { get; set; }
}
