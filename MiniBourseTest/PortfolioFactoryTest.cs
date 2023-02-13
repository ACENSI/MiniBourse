namespace MiniBourseTest
{
    public class PortfolioFactoryTest
    {
        private IPortfolioFactory _portfolioFactory;

        public PortfolioFactoryTest()
        {
            _portfolioFactory = new PortfolioFactory();
        }

        [Fact]
        public void CreatePortFolio()
        {
            const int cash = 1000;
            var portfolio = _portfolioFactory.CreatePortFolio(cash);
            Assert.Equal(cash, portfolio.Cash);
        }
    }
}
