namespace MiniBourseTest
{
    public class InterestCalculatorLowRiskStrategyTest
    {
        private IInterestCalculatorStrategy _interestCalculator;

        public InterestCalculatorLowRiskStrategyTest()
        {
            _interestCalculator = new InterestCalculatorLowRiskStrategy();
        }

        [Fact]
        public void Calculate()
        {
            var shareCurrentValue = 10;
            var shareNextValue = _interestCalculator.Calculate(shareCurrentValue);
            Assert.Equal(shareCurrentValue * 1.05, shareNextValue);
        }  
    }
}
