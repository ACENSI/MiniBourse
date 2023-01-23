namespace MiniBourse
{
    internal class InterestCalculatorMediumRiskStrategy : IInterestCalculatorStrategy
    {
        private readonly IRandomProxy _randomProxy;
        private readonly int _minMaxValue;

        public InterestCalculatorMediumRiskStrategy(IRandomProxy randomProxy, int minMaxValue)
        {
            _randomProxy = randomProxy;
            _minMaxValue = minMaxValue;
        }
        public double Calculate(double shareCurrentValue)
        {
            return shareCurrentValue * (105 + _randomProxy.Next(-_minMaxValue, _minMaxValue)) / 100;
        }
    }
}