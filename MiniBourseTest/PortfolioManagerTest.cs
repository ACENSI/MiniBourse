using Moq;

namespace MiniBourseTest
{
    public class PortfolioManagerTest
    {
        private Mock<IMarketExchange> _marketMock;
        private IPortfolioManager _portfolioManager;

        public PortfolioManagerTest()
        {
            _marketMock = new Mock<IMarketExchange>();
            _portfolioManager = new PortfolioManager(_marketMock.Object);
        }

        [Fact]
        public void CreatePortFolio()
        {
            const int cash = 1000;
            var portfolio = _portfolioManager.CreatePortFolio(cash);
            Assert.Equal(cash, portfolio.Cash);
        }

        [Fact]
        public void BuyShare()
        {
            const int cash = 1000;
            _marketMock.Setup(x => x.Shares).Returns(new List<Share> { new Share
            {
                Price = 10
            }, });
            var portfolio = _portfolioManager.CreatePortFolio(cash);

            const int Quantity = 100;
            const int shareId = 0;
            _portfolioManager.BuyShare(portfolio, shareId, Quantity);
            Assert.Equal(0, portfolio.Cash);
            Assert.Equal(Quantity, portfolio.Shares[shareId]);
        }

        [Fact]
        public void BuyShareMoreThanPossible()
        {
            const int cash = 1000;
            _marketMock.Setup(x => x.Shares).Returns(new List<Share> { new Share
            {
                Price = 10
            }, });
            var portfolio = _portfolioManager.CreatePortFolio(cash);

            Assert.Throws<InvalidOperationException>(() => { _portfolioManager.BuyShare(portfolio, shareId: 0, quantity: 1000); });
        }

        [Fact]
        public void BuyShareThatDoesNotExist()
        {
            const int cash = 1000;
            _marketMock.Setup(x => x.Shares).Returns(new List<Share> { new Share
            {
                Price = 10
            }, });
            var portfolio = _portfolioManager.CreatePortFolio(cash);

            Assert.Throws<ArgumentOutOfRangeException>(() => { _portfolioManager.BuyShare(portfolio, shareId: 1, quantity: 1); });
        }
    }
}
