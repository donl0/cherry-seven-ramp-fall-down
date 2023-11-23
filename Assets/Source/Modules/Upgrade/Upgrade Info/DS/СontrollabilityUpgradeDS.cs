public class СontrollabilityUpgradeDS: UpgradeDS
{
    private int _turnSteering;
    private int _wheelMass;
    private float _extremumSleep;
    private float _extremumValue;
    private float _asymptoteSleep;
    private float _asymptoteValue;
    private float _stiffness;
    
    public int TurnSteering => _turnSteering;
    public int WheelMass => _wheelMass;
    public float ExtremumSleep => _extremumSleep;
    public float ExtremumValue => _extremumValue;
    public float AsymptoteSleep => _asymptoteSleep;
    public float AsymptoteValue => _asymptoteValue;
    public float Stiffness => _stiffness;

    public СontrollabilityUpgradeDS(CarType car, int turnSteering, int wheelMass, float extremumSleep, float extremumValue, float asymptoteSleep, float asymptoteValue, float stiffness , int level) : base(car, level)
    {
        _turnSteering = turnSteering;
        _wheelMass = wheelMass;
        _extremumSleep = extremumSleep;
        _extremumValue = extremumValue;
        _asymptoteSleep = asymptoteSleep;
        _asymptoteValue = asymptoteValue;
        _stiffness = stiffness;
    }
}