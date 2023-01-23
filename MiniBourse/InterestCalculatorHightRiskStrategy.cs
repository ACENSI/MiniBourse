namespace MiniBourse
{
    internal class InterestCalculatorHightRiskStrategy : IInterestCalculatorStrategy
    {
        private readonly IRandomProxy _randomProxy;
        private readonly int _minMaxValue;

        public InterestCalculatorHightRiskStrategy(IRandomProxy randomProxy, int minMaxValue)
        {
            _randomProxy = randomProxy;
            _minMaxValue = minMaxValue;
        }
        public double Calculate(double shareCurrentValue)
        {
            return shareCurrentValue * (100 + _randomProxy.Next(-_minMaxValue, _minMaxValue)) / 100;
        }
    }
}