
[System.Serializable]
public struct Country
{
    public string countryName;

    public int economy;

    public int freedom;

    public int humanity;

    public Country(string countryName, int economy, int freedom, int humanity)
    {
        this.countryName = countryName;
        this.economy = economy;
        this.freedom = freedom;
        this.humanity = humanity;
    }
}
