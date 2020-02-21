using System;
using System.Collections.Generic;
using System.Text;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.Business.Abstract
{
    public interface IPortfolioService
    {
        List<Portfolio> GetAllPortfolios();
        List<Portfolio> GetPortfoliosByDeveloperId(int developerId);

        Portfolio GetPortfolioById(int Id);

        void Add(Portfolio portfolio);
        void Update(Portfolio portfolio);
        void Delete(Portfolio portfolio);
    }
}
