using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YazilimIsi.Business.Abstract;
using YazilimIsi.Business.Concrete;
using YazilimIsi.DataAccess.Concrete;
using YazilimIsi.Entity.Models;
using YazilimIsi.WebApp.Models;

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
        public IActionResult Teklifler()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            List<Offer> offers = _offerService.GetOffersByDeveloperId(developerId);
            return View(offers);
        }

        /* Yazilimci Verdigi Teklif Detayi */
        public IActionResult TeklifDetay(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Offer offer = _offerService.GetOfferById(Id);
            if (offer == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if(offer.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(offer);
        }



        /* Yazilimci Portfolyo Listesi */
        public IActionResult Portfolyo()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            List<Portfolio> portfolyo = _portfolioService.GetPortfoliosByDeveloperId(developerId);
            return View(portfolyo);
        }

        /* Yazilimci Portfolyo Detay Detayi */
        public IActionResult PortfolyoDetay(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Portfolio portfolyo = _portfolioService.GetPortfolioById(Id);
            if (portfolyo == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (portfolyo.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(portfolyo);
        }

        /* Yazilimci Portfolyo Ekleme Islemi */
        [HttpPost]
        public IActionResult PortfolyoEkle(YazilimciViewModels yazilimciViewModels)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (yazilimciViewModels.FormPortfolio.ProjectName.Length > 1 && yazilimciViewModels.FormPortfolio.Description.Length > 5)
            {
                yazilimciViewModels.FormPortfolio.DeveloperId = developerId;
                _portfolioService.Add(yazilimciViewModels.FormPortfolio);
            }
            TempData["AddSuccessMessage"] = "Portfolyo Ekleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Portfolyo Duzenleme Islemi */
        [HttpPost]
        public IActionResult PortfolyoDuzenle(int Id, Portfolio portfolio)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Portfolio findPortfolio = _portfolioService.GetPortfolioById(Id);
            if (findPortfolio == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (findPortfolio.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            findPortfolio.ProjectName = portfolio.ProjectName;
            findPortfolio.Description = portfolio.Description;
            findPortfolio.CreatedDate = portfolio.CreatedDate;
            findPortfolio.ProjectUrl = portfolio.ProjectUrl;
            _portfolioService.Update(findPortfolio);
            TempData["AddSuccessMessage"] = "Portfolyo Düzenleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Portfolyo Silme Islemi */
        public IActionResult PortfolyoSil(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Portfolio portfolyo = _portfolioService.GetPortfolioById(Id);
            if (portfolyo == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (portfolyo.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            _portfolioService.Delete(portfolyo);
            TempData["AddSuccessMessage"] = "Portfolyo Silme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }



        /* Yazilimci Oduller Listesi */
        public IActionResult Oduller()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            List<Award> awards = _awardService.GetAwardsByDeveloperId(developerId);
            return View(awards);
        }

        /* Yazilimci Odul Detay Detayi */
        public IActionResult OdulDetay(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Award award = _awardService.GetAwardById(Id);
            if (award == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (award.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(award);
        }

        /* Yazilimci Odul Ekleme Islemi */
        [HttpPost]
        public IActionResult OdulEkle(YazilimciViewModels yazilimciViewModels)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (yazilimciViewModels.FormAward.Title.Length > 1 && yazilimciViewModels.FormAward.Description.Length > 5)
            {
                yazilimciViewModels.FormAward.DeveloperId = developerId;
                _awardService.Add(yazilimciViewModels.FormAward);
            }
            TempData["AddSuccessMessage"] = "Ödül Ekleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Odul Duzenleme Islemi */
        [HttpPost]
        public IActionResult OdulDuzenle(int Id, Award award)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Award findAward = _awardService.GetAwardById(Id);
            if (findAward == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (findAward.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            findAward.Title = award.Title;
            findAward.Description = award.Description;
            findAward.Date = award.Date;
            _awardService.Update(findAward);
            TempData["AddSuccessMessage"] = "Ödül Düzenleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Odul Silme Islemi */
        public IActionResult OdulSil(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Award award = _awardService.GetAwardById(Id);
            if (award == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (award.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            _awardService.Delete(award);
            TempData["AddSuccessMessage"] = "Ödül Silme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }


    }
}