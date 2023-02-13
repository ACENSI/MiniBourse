namespace MiniBourse
{
    internal class Share : IShare
    {
        public string Name { get; internal set; }
        public RiskLevel RiskLevel { get; internal set; }
        public double Price { get; set; }
        public int Id { get; internal set; }
    }
}