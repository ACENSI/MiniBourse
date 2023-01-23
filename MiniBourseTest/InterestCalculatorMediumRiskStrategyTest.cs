using Moq;

namespace MiniBourseTest
{
    public class InterestCalculatorMediumRiskStrategyTest
    {
        private Mock<IRandomProxy> _randomMock;
        private IInterestCalculatorStrategy _interestCalculator;

        public InterestCalculatorMediumRiskStrategyTest()
        {
            _randomMock = new Mock<IRandomProxy>();
            _interestCalculator = new InterestCalculatorMediumRiskStrategy(_randomMock.Object, 10);
        }

        [Fact]
        public void Calculate()
        {
            const int Value = 6;
            _randomMock.Setup(x=> x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(Value);
            var shareCurrentValue = 10.0;
            var shareNextValue = _interestCalculator.Calculate(shareCurrentValue);
            Assert.Equal(shareCurrentValue * (105 + Value) / 100, shareNextValue);
        }  
    }
}
