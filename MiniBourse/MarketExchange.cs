namespace MiniBourse
{
    internal class MarketExchange : IMarketExchange
    {
        private readonly IShareFactory _shareFactory;
        private readonly IPlayerFactory _playerFactory;
        private readonly Dictionary<RiskLevel, IInterestCalculatorStrategy> _interestCalculatorStrategies = new();
        public MarketExchange(IShareFactory shareFactory, IPlayerFactory playerFactory, IInterestCalculatorStrategy interestCalculatorLowRiskStrategy,
            IInterestCalculatorStrategy interestCalculatorMediumRiskStrategy, IInterestCalculatorStrategy interestCalculatorHightRiskStrategy)
        {
            _interestCalculatorStrategies[RiskLevel.Low] = interestCalculatorLowRiskStrategy;
            _interestCalculatorStrategies[RiskLevel.Medium] = interestCalculatorMediumRiskStrategy;
            _interestCalculatorStrategies[RiskLevel.Hight] = interestCalculatorHightRiskStrategy;

            _shareFactory = shareFactory;
            _playerFactory = playerFactory;
            Shares = new List<IShare>();
            Players = new List<IPlayer>();
        }
        public IList<IShare> Shares { get; internal set; }
        public IList<IPlayer> Players { get; internal set; }

        public void InitMarket(int numberOfPlayer, int beginningCash)
        {
            Shares.Add(_shareFactory.Create(RiskLevel.Low));
            Shares.Add(_shareFactory.Create(RiskLevel.Medium));
            Shares.Add(_shareFactory.Create(RiskLevel.Hight));
            for (int i = 0; i < numberOfPlayer; i++)
            {
                Players.Add(_playerFactory.Create(beginningCash));
            }
        }

        public void BuyShare(int playerId, int shareId, int quantity)
        {
            var player = Players.First(p => p.Id == playerId);
            var share = Shares.First(s => s.Id == shareId);

            double price = quantity * share.Price;
            if (price > player.Portfolio.Cash)
            {
                throw new InvalidOperationException("not enough cash");
            }
            player.Portfolio.Cash -= price;

            if (player.Portfolio.Shares.ContainsKey(shareId))
            {
                player.Portfolio.Shares[shareId] += quantity;
            }
            else
            {
                player.Portfolio.Shares[shareId] = quantity;
            }
        }

        public void ChangePrice()
        {
            foreach (var share in Shares)
            {
                share.Price = _interestCalculatorStrategies[share.RiskLevel].Calculate(share.Price);
            }
        }
    }
}