namespace MiniBourse
{
    internal class Player : IPlayer
    {
        public IPortfolio Portfolio { get; set; }
        public int Id { get; internal set; }
    }
}