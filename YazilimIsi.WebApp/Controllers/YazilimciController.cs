using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YazilimIsi.Business.Abstract;
using YazilimIsi.Business.Concrete;
using YazilimIsi.DataAccess.Concrete;

namespace YazilimIsi.WebApp.Controllers
{
    public class YazilimciController : Controller
    {

        IDeveloperService _developerService = new DeveloperManager(new EfDeveloperDal());
        IPortfolioService _portfolioService = new PortfolioManager(new EfPortfolioDal());
        IAwardService _awardService = new AwardManager(new EfAwardDal());

        IJobService _jobService = new JobManager(new EfJobDal());
        IOfferService _offerService = new OfferManager(new EfOfferDal());
        ISupportService _supportService = new SupportManager(new EfSupportDal());
        IAccountActivityService _accountActivityService = new AccountActivityManager(new EfAccountActivityDal());

        /* Yazilimci Herkese Acik Profil */
        public IActionResult Profil(int Id)
        {
            return View();
        }

        /* Yazilimci Verdigi Teklifler Listesi */
        public IActionResult Teklifler(int Id)
        {
            return View();
        }

        /* Yazilimci Verdigi Teklif Detayi */
        public IActionResult TeklifDetay(int Id)
        {
            return View();
        }



    }
}