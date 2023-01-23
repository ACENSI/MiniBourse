namespace MiniBourse
{
    internal class PortfolioManager: IPortfolioManager
    {
        private readonly IMarketExchange _market;

        public PortfolioManager(IMarketExchange market)
        {
            _market = market;
        }

        public void BuyShare(IPortfolio portfolio, int shareId, int quantity)
        {
            if (shareId > _market.Shares.Count() - 1 || shareId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(shareId));
            }
            var share = _market.Shares.ElementAt(shareId);
            var price = share.Price * quantity;
            if (price > portfolio.Cash)
            {
                throw new InvalidOperationException("not enough cash");
            }
            portfolio.Shares[shareId] = quantity;
            portfolio.Cash -= price;
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