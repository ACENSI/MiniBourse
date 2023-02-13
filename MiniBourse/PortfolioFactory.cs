namespace MiniBourse
{
    internal class PortfolioFactory : IPortfolioFactory
    {
        public PortfolioFactory()
        {
        }

        public IPortfolio CreatePortFolio(double cash)
        {
            return new Portfolio
            {
                Cash = cash,
            };
        }
    }
}