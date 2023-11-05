using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "car/car prise list")]
public class CarPriseList: ScriptableObject
{
    [SerializeField] private List<CarPrise> _carPrises;

    public int GetPrise(CarType car)
    {
        int prise = _carPrises.FirstOrDefault(c => c.Car == car).Prise;

        return prise;
    }
}