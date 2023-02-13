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
            var name = _ShareNames[_count++];
            return new Share { Id = _count, Name = name, RiskLevel = riskLevel, Price = _count * 10};
        }
    }
}
