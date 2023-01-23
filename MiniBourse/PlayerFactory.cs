namespace MiniBourse
{
    internal class PlayerFactory : IPlayerFactory
    {
        private readonly IPortfolioManager _portfolioManager;

        public PlayerFactory(IPortfolioManager portfolioManager)
        {
            _portfolioManager = portfolioManager;
        }
        public IPlayer Create(double cash)
        {
            return new Player
            {
                Portfolio = _portfolioManager.CreatePortFolio(cash),
            };
        }
    }
}