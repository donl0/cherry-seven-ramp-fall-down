public class CarPartEffector : CircleEffector<InventoryCarPartsHandler>
{
    private CarPart _carPart;

    public CarPartEffector(CarPart carPart)
    {
        _carPart = carPart;
    }

    public override void Affect(InventoryCarPartsHandler value)
    {
        value.Add(_carPart);
    }
}
