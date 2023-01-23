namespace MiniBourse
{
    internal interface IShareFactory
    {
        IShare Create(RiskLevel riskLevel);
    }
}