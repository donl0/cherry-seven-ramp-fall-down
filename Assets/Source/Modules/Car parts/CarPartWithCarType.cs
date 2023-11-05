using System.Collections.Generic;
using System.Linq;

public class CarPartWithCarType
{
    private Dictionary<CarType, List<CarPart>> _carParts = new Dictionary<CarType, List<CarPart>>();

    public CarPartWithCarType()
    {
        _carParts.Add(CarType.police, new List<CarPart>()
        {
            CarPart.cherrySevenEngine
        });
        _carParts.Add(CarType.police2, new List<CarPart>()
        {
            CarPart.cherrySevenEngine
        });
    }

    public List<CarPart> GetParts(CarType car)
    {
        List<CarPart> parts = _carParts.FirstOrDefault(c => c.Key == car).Value;

        return parts;
    }
}
