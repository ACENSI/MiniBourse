namespace MiniBourse
{
    internal interface IMarketExchange
    {
        IEnumerable<IShare> Shares { get; }
        void InitMarket();
    }
}