namespace MiniBourse
{
    internal class InterestCalculatorLowRiskStrategy : IInterestCalculatorStrategy
    {
        public double Calculate(double shareCurrentValue)
        {
            return shareCurrentValue * 1.05;
        }
    }
}