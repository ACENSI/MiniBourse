namespace MiniBourse
{
    internal interface IPortfolioFactory
    {
        IPortfolio CreatePortFolio(double cash);
    }
}