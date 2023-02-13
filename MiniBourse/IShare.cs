namespace MiniBourse
{
    internal interface IShare
    {
        int Id { get; }
        string Name { get; }
        RiskLevel RiskLevel { get; }
        double Price { get; set; }
    }
}