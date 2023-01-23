using Moq;

namespace MiniBourseTest
{
    public class PlayerFactoryTest
    {
        private IPlayerFactory _playerFactory;

        public PlayerFactoryTest()
        {
            var portfolioManagerMock = new Mock<IPortfolioManager>();
            portfolioManagerMock.Setup(p => p.CreatePortFolio(It.IsAny<double>())).Returns<double>((cash) => new Portfolio { Cash = cash });
            _playerFactory = new PlayerFactory(portfolioManagerMock.Object);
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