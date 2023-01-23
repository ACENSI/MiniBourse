using Moq;

namespace MiniBourseTest
{
    public class InterestCalculatorHightRiskStrategyTest
    {
        private Mock<IRandomProxy> _randomMock;
        private IInterestCalculatorStrategy _interestCalculator;

        public InterestCalculatorHightRiskStrategyTest()
        {
            _randomMock = new Mock<IRandomProxy>();
            _interestCalculator = new InterestCalculatorHightRiskStrategy(_randomMock.Object, 50);
        }

        [Fact]
        public void Calculate()
        {
            const int Value = 45;
            _randomMock.Setup(x=> x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(Value);
            var shareCurrentValue = 10.0;
            var shareNextValue = _interestCalculator.Calculate(shareCurrentValue);
            Assert.Equal(shareCurrentValue * (100 + Value) / 100, shareNextValue);
        }  
    }
}
