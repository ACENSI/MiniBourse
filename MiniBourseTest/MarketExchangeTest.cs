
namespace MiniBourseTest
{
    public class MarketExchangeTest
    {
        [Fact]
        public void InitialiseMarket()
        {
            var Market = new MarketExchange();
            Market.InitMarket();

            Assert.Equal(3, Market.Shares.Count());
            Assert.Equal(RiskLevel.Low, Market.Shares.ElementAt(0).RiskLevel);
            Assert.Equal(RiskLevel.Medium, Market.Shares.ElementAt(1).RiskLevel);
            Assert.Equal(RiskLevel.Hight, Market.Shares.ElementAt(2).RiskLevel);
        }
    }
}
