namespace MiniBourse
{
    internal interface IInterestCalculatorStrategy
    {
        double Calculate(double shareCurrentValue);
    }
}