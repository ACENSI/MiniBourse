namespace MiniBourse
{
    internal class ShareFactory : IShareFactory
    {
        private int _count = 0;
        private static readonly List<string> _ShareNames = new List<string>
        {
            "Acensi",
            "Société Général",
            "Crédit Agrilcole",
            "Natixis"
        };

        public IShare Create(RiskLevel riskLevel)
        {
            return new Share { Name = _ShareNames[_count++], RiskLevel = riskLevel };
        }
    }
}
