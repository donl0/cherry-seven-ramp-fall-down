internal class SkinMainCarInteracter : InceracterListener<SkinCarMover>
{
    private CurrentCarHandler _currentCarHandler;

    protected override void OnInteracted(CarType val)
    {
        _currentCarHandler = new CurrentCarHandler();
        _currentCarHandler.ChangeCar(val);
    }
}