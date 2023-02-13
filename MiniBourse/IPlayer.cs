namespace MiniBourse
{
    internal interface IPlayer
    {
        int Id { get; }
        IPortfolio Portfolio { get; }
    }
}