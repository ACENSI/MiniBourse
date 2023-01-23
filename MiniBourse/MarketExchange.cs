namespace MiniBourse
{
    internal class MarketExchange : IMarketExchange
    {
        private readonly IShareFactory _shareFactory;

        public MarketExchange()
        {
            _shareFactory = new ShareFactory();
        }
        public IEnumerable<IShare> Shares { get; internal set; }

        public void InitMarket()
        {
            Shares = new List<IShare>
            {
                _shareFactory.Create(RiskLevel.Low),
                _shareFactory.Create(RiskLevel.Medium),
                _shareFactory.Create(RiskLevel.Hight)
            };
        }
    }
}
