using UnityEngine;

public class CartPartCirclePresenter : BaseCirclePresenter<InventoryCarPartsHandler, CarPart>
{
    [SerializeField] private CarPart _carPart;
    
    protected override CircleEffector<InventoryCarPartsHandler> InitEffector()
    {
        var effector = new CarPartEffector(_carPart);
        return effector;
    }
}
