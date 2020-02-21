using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Business.Abstract;
using YazilimIsi.DataAccess.Abstract;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Concrete
{
    public class PortfolioManager : IPortfolioService
    {

        private IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void Add(Portfolio portfolio)
        {
            _portfolioDal.Add(portfolio);
        }

        public void Delete(Portfolio portfolio)
        {
            _portfolioDal.Delete(portfolio);
        }

        public List<Portfolio> GetAllPortfolios()
        {
            return _portfolioDal.GetAll();
        }

        public Portfolio GetPortfolioById(int Id)
        {
            return _portfolioDal.Get(x => x.Id == Id);
        }

        public List<Portfolio> GetPortfoliosByDeveloperId(int developerId)
        {
            return _portfolioDal.GetAll(x => x.DeveloperId == developerId);
        }

        public void Update(Portfolio portfolio)
        {
            _portfolioDal.Update(portfolio);
        }
    }
}
