namespace MiniBourse
{
    internal interface IPortfolio
    {
        double Cash { get; set; }

        IDictionary<int, int> Shares { get; }
    }
}