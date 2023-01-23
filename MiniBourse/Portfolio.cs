namespace MiniBourse
{
    internal class Portfolio : IPortfolio
    {
        public double Cash { get; set; }

        public IDictionary<int, int> Shares { get; private set; } = new Dictionary<int, int>();
    }
}