using UnityEngine;

[CreateAssetMenu(menuName = "car/car types list/opened list")]
public class OpenedCarListCircularAccess : CarTypesListCircularAccess
{
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
}
