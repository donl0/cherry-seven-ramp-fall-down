using System.Collections.Generic;
using UnityEngine;

//#if UNITY_WEBGL || !UNITY_EDITOR
//using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
//#endif

[CreateAssetMenu(menuName = "car/car types list/opened list")]
public class OpenedCars : CarTypesListCircularAccess
{
    private const CarType STARTCAR = CarType.niisan;

    public void Add(CarType car)
    {
        Cars.Add(car);
    }

    public bool CheckIfContains(CarType car)
    {
        foreach (var carinList in Cars)
        {
            if (carinList == car)
                return true;
        }

        return false;
    }
    
    public override void Load()
    {
        if (PlayerPrefs.HasKey(SaveKey) == false)
        {
            Cars = new List<CarType>() {STARTCAR};
            return;
        }
        
        var json = PlayerPrefs.GetString(SaveKey);
        Cars = JsonUtility.FromJson<DataTransfer>(json).Cars;
    }

    public override void Save()
    {
        var json = JsonUtility.ToJson(new DataTransfer(Cars));
        PlayerPrefs.SetString(SaveKey, json);
    }
}

internal class DataTransfer
{
    [SerializeField] private List<CarType> _cars;
    public List<CarType> Cars => new List<CarType>(_cars);

    public DataTransfer(List<CarType> cars)
    {
        _cars = cars;
    }
}
