public class UpgradeViewDS
{
    private string _level;
    private string _price;

    public string Level => _level;
    public string Price => _price;

    public UpgradeViewDS(string level, string price)
    {
        _level = level;
        _price = price;
    }
}