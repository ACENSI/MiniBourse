using Moq;

namespace MiniBourseTest
{
    public class PlayerFactoryTest
    {
        private IPlayerFactory _playerFactory;

        public PlayerFactoryTest()
        {
            var portfolioFactoryMock = new Mock<IPortfolioFactory>();
            portfolioFactoryMock.Setup(p => p.CreatePortFolio(It.IsAny<double>())).Returns<double>((cash) => new Portfolio { Cash = cash });
            _playerFactory = new PlayerFactory(portfolioFactoryMock.Object);
        }

        [Fact]
        public void CreatePlayer()
        {
            var cash = 1000;
            var player = _playerFactory.Create(cash);
            Assert.Equal(cash, player.Portfolio.Cash);
        }
    }
}