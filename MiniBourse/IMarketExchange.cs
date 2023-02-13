namespace MiniBourse
{
    internal interface IMarketExchange
    {
        IList<IShare> Shares { get; }
        IList<IPlayer> Players { get; }
        void InitMarket(int numberOfPlayer, int beginningCash);
    }
}