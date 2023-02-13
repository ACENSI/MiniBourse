namespace MiniBourse
{
    internal class PlayerFactory : IPlayerFactory
    {
        private int _count = 0;
        private readonly IPortfolioFactory _portfolioFactory;

        public PlayerFactory(IPortfolioFactory portfolioFactory)
        {
            _portfolioFactory = portfolioFactory;
        }
        public IPlayer Create(double cash)
        {
            _count++;
            return new Player
            {
                Id = _count,
                Portfolio = _portfolioFactory.CreatePortFolio(cash),
            };
        }
    }
}