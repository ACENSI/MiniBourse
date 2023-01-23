namespace MiniBourse
{
    internal interface IPortfolioManager
    {
        void BuyShare(IPortfolio portfolio, int shareId, int quantity);
        IPortfolio CreatePortFolio(double cash);
    }
}