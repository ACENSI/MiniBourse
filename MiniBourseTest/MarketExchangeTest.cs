using Moq;

namespace MiniBourseTest
{
    public class MarketExchangeTest
    {
        private Mock<IInterestCalculatorStrategy> _interestCalculatorLowRiskStrategyMock;
        private Mock<IInterestCalculatorStrategy> _interestCalculatorMediumRiskStrategyMock;
        private Mock<IInterestCalculatorStrategy> _interestCalculatorHightRiskStrategyMock;
        private MarketExchange _market;

        public MarketExchangeTest()
        {
            _interestCalculatorLowRiskStrategyMock = new Mock<IInterestCalculatorStrategy>();
            _interestCalculatorMediumRiskStrategyMock = new Mock<IInterestCalculatorStrategy>();
            _interestCalculatorHightRiskStrategyMock = new Mock<IInterestCalculatorStrategy>();
            _market = new MarketExchange(new ShareFactory(), new PlayerFactory(new PortfolioFactory()), _interestCalculatorLowRiskStrategyMock.Object,
                _interestCalculatorMediumRiskStrategyMock.Object, _interestCalculatorHightRiskStrategyMock.Object);
        }

        [Fact]
        public void InitialiseMarket()
        {
            var numberOfPlayer = 3;
            var beginningCash = 1000;

            Assert.NotNull(_market.Shares);
            Assert.NotNull(_market.Players);
            Assert.Empty(_market.Shares);
            Assert.Empty(_market.Players);
            _market.InitMarket(numberOfPlayer, beginningCash );
            Assert.NotEmpty(_market.Shares);
            Assert.NotEmpty(_market.Players);

            Assert.Equal(3, _market.Shares.Count());
            Assert.Equal(RiskLevel.Low, _market.Shares.ElementAt(0).RiskLevel);
            Assert.Equal(RiskLevel.Medium, _market.Shares.ElementAt(1).RiskLevel);
            Assert.Equal(RiskLevel.Hight, _market.Shares.ElementAt(2).RiskLevel);

            Assert.Equal(numberOfPlayer, _market.Players.Count());
            foreach (var player in _market.Players)
            {
                Assert.Equal(beginningCash, player.Portfolio.Cash);
            }
        }

        [Fact]
        public void BuyShare()
        {
            var numberOfPlayer = 3;
            var beginningCash = 1000;
            _market.InitMarket(numberOfPlayer, beginningCash);

            const int Quantity = 100;
            const int shareId = 1;
            var playerId = 1;
            _market.BuyShare(playerId, shareId, Quantity);
            var player = _market.Players.First(x => x.Id == playerId);
            Assert.Equal(0, player.Portfolio.Cash);
            Assert.Equal(Quantity, player.Portfolio.Shares[shareId]);
        }

        [Fact]
        public void BuyShareTwice()
        {
            var numberOfPlayer = 3;
            var beginningCash = 1000;
            _market.InitMarket(numberOfPlayer, beginningCash);


            const int Quantity = 10;
            const int shareId = 1;
            var playerId = 1;
            _market.BuyShare(playerId, shareId, Quantity);
            _market.BuyShare(playerId, shareId, Quantity);
            var player = _market.Players.First(x => x.Id == playerId);
            Assert.Equal(1000 - (Quantity * 10 * 2), player.Portfolio.Cash);
            Assert.Equal(Quantity * 2, player.Portfolio.Shares[shareId]);
        }

        [Fact]
        public void BuyShareMoreThanPossible()
        {
            var numberOfPlayer = 3;
            var beginningCash = 1000;
            _market.InitMarket(numberOfPlayer, beginningCash);

            Assert.Throws<InvalidOperationException>(() => { _market.BuyShare(playerId: 1, shareId: 1, quantity: 1000); });
        }

        [Fact]
        public void ChangePrice() 
        {
            var numberOfPlayer = 3;
            var beginningCash = 1000;
            _interestCalculatorLowRiskStrategyMock.Setup(x => x.Calculate(It.IsAny<double>())).Returns<double>((x) => x + 5);
            _interestCalculatorMediumRiskStrategyMock.Setup(x => x.Calculate(It.IsAny<double>())).Returns<double>((x) => x + 15);
            _interestCalculatorHightRiskStrategyMock.Setup(x => x.Calculate(It.IsAny<double>())).Returns<double>((x) => x - 8);
            _market.InitMarket(numberOfPlayer, beginningCash);
            Assert.Equal(10, _market.Shares[0].Price);
            Assert.Equal(20, _market.Shares[1].Price);
            Assert.Equal(30, _market.Shares[2].Price);

            _market.ChangePrice();
            Assert.Equal(15, _market.Shares[0].Price);
            Assert.Equal(35, _market.Shares[1].Price);
            Assert.Equal(22, _market.Shares[2].Price);

            _market.ChangePrice();
            Assert.Equal(20, _market.Shares[0].Price);
            Assert.Equal(50, _market.Shares[1].Price);
            Assert.Equal(14, _market.Shares[2].Price);
        }
    }
}