namespace MiniBourse
{
    internal interface IPlayerFactory
    {
        IPlayer Create(double cash);
    }
}