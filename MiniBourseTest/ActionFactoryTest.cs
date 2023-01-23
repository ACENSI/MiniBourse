using AutoFixture;

namespace MiniBourseTest
{
    public class ActionFactoryTest
    {
        private readonly IShareFactory _factory;

        public ActionFactoryTest()
        {
            _factory = new ShareFactory();
        }

        [Theory]
        [InlineData(RiskLevel.Low)]
        [InlineData(RiskLevel.Medium)]
        [InlineData(RiskLevel.Hight)]
        internal void CreateAnActionWithRisk(RiskLevel riskLevel)
        {
            var result = _factory.Create(riskLevel);

            Assert.Equal(riskLevel, result.RiskLevel);
        }

        [Fact]
        public void FirstWillBeNamedAcensi()
        {
            var fixture = new Fixture();
            var factory = new ShareFactory();
            var result = factory.Create(fixture.Create<RiskLevel>());
            Assert.Equal("Acensi", result.Name);
        }
    }
}