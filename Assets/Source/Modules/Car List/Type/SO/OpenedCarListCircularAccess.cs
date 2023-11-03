using UnityEngine;

[CreateAssetMenu(menuName = "Car types list/opened list")]
public class OpenedCarListCircularAccess : CarTypesListCircularAccess
{
    public void Add(CarType car)
    {
        Cars.Add(car);
    }
}
