namespace MiniBourse
{
    internal interface IShare
    {
        string Name { get; }
        RiskLevel RiskLevel { get; }
        double Price { get; }
    }
}