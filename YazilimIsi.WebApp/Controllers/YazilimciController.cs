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
using YazilimIsi.HelperFileUploader.Concrete;
using YazilimIsi.WebApp.Models;

namespace YazilimIsi.WebApp.Controllers
{
    public class YazilimciController : Controller
    {

        IDeveloperService _developerService = new DeveloperManager(new EfDeveloperDal());
        IPortfolioService _portfolioService = new PortfolioManager(new EfPortfolioDal());
        IAwardService _awardService = new AwardManager(new EfAwardDal());
        IEducationService _educationService = new EducationManager(new EfEducationDal());

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



        /* Yazilimci Egitimler Listesi */
        public IActionResult Egitim()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            List<Education> educations = _educationService.GetEducationsByDeveloperId(developerId);
            return View(educations);
        }

        /* Yazilimci Egitim Detay Detayi */
        public IActionResult EgitimDetay(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Education education = _educationService.GetEducationById(Id);
            if (education == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (education.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(education);
        }

        /* Yazilimci Egitim Ekleme Islemi */
        [HttpPost]
        public IActionResult EgitimEkle(YazilimciViewModels yazilimciViewModels)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (yazilimciViewModels.FormEducation.Title.Length > 1 && yazilimciViewModels.FormEducation.Description.Length > 5)
            {
                yazilimciViewModels.FormEducation.DeveloperId = developerId;
                _educationService.Add(yazilimciViewModels.FormEducation);
            }
            TempData["AddSuccessMessage"] = "Eğitim Ekleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Odul Duzenleme Islemi */
        [HttpPost]
        public IActionResult EgitimDuzenle(int Id, Education education)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Education findEducation = _educationService.GetEducationById(Id);
            if (findEducation == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (findEducation.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            findEducation.Title = education.Title;
            findEducation.Description = education.Description;
            findEducation.StartDate = education.StartDate;
            findEducation.EndDate = education.EndDate;
            _educationService.Update(findEducation);
            TempData["AddSuccessMessage"] = "Eğitim Düzenleme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        /* Yazilimci Egitim Silme Islemi */
        public IActionResult EgitimSil(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Education education = _educationService.GetEducationById(Id);
            if (education == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (education.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            _educationService.Delete(education);
            TempData["AddSuccessMessage"] = "Eğitim Silme Başarıyla Gerçekleştirildi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }



        /* Isveren Hesap Hareketleri Sayfasi */
        public IActionResult HesapHareketleri()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            List<AccountActivity> activities = _accountActivityService.GetAllAccountActivitiesByDeveloperId(developerId);
            return View(activities);
        }

        /* Isveren Hesap Hareketi Detay Sayfasi */
        public IActionResult HesapHareketDetay(int Id)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            AccountActivity accountActivity = _accountActivityService.GetAccountActivityById(Id);
            if (accountActivity == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (accountActivity.DeveloperId != developerId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(accountActivity);
        }



        /* Yazilimci Profil Duzenleme Islemi */
        public IActionResult ProfilDuzenle()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Developer developer = _developerService.GetDeveloperById(developerId);
            if (developer == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(developer);
        }
        [HttpPost]
        public IActionResult DuzenleTemel(int Id, Developer developer)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer findDeveloper = _developerService.GetDeveloperById(developerId);
            findDeveloper.Name = developer.Name;
            findDeveloper.Surname = developer.Surname;
            findDeveloper.Job = developer.Job;
            // findDeveloper.Mail = user.Mail;
            findDeveloper.Phone = developer.Phone;
            _developerService.Update(findDeveloper);

            TempData["AddSuccessMessage"] = "Profil Bilgileri Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        [HttpPost]
        public IActionResult DuzenleAciklama(int Id, Developer developer)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer findDeveloper = _developerService.GetDeveloperById(developerId);
            findDeveloper.Description = developer.Description;
            _developerService.Update(findDeveloper);

            TempData["AddSuccessMessage"] = "Açıklama Yazısı Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        [HttpPost]
        public IActionResult DuzenleAdres(int Id, Developer developer)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer findDeveloper = _developerService.GetDeveloperById(developerId);
            findDeveloper.Country = developer.Country;
            findDeveloper.City = developer.City;
            findDeveloper.Address = developer.Address;
            _developerService.Update(findDeveloper);

            TempData["AddSuccessMessage"] = "Adres Bilgileri Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        [HttpPost]
        public IActionResult DuzenleSosyal(int Id, Developer developer)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer findDeveloper = _developerService.GetDeveloperById(developerId);
            findDeveloper.MediaWebsite = developer.MediaWebsite;
            findDeveloper.MediaLinkedin = developer.MediaLinkedin;
            findDeveloper.MediaGithub = developer.MediaGithub;
            findDeveloper.MediaMedium = developer.MediaMedium;
            _developerService.Update(findDeveloper);

            TempData["AddSuccessMessage"] = "Sosyal Medya Bilgileri Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }

        [HttpPost]
        public IActionResult DuzenleSifre(int Id, string EskiSifre, string YeniSifre1, string YeniSifre2)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer developer = _developerService.GetDeveloperById(developerId);
            if (developer.Password == EskiSifre)
            {
                if (YeniSifre1 == YeniSifre2)
                {
                    developer.Password = YeniSifre1;
                    _developerService.Update(developer);
                }
                else
                {
                    TempData["UpdateErrorMessage"] = "Girdiğiniz Şifreler Birbiriyle Aynı Değil.";
                    return RedirectToAction("ProfilDuzenle");
                }
            }
            else
            {
                TempData["UpdateErrorMessage"] = "Eski Şifrenizi Yanlış Girdiniz.";
                return RedirectToAction("ProfilDuzenle");
            }

            TempData["AddSuccessMessage"] = "Şifre Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }



        /* Yazilimci Fotograf Duzenleme Islemi */
        public IActionResult FotografDuzenle()
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            Developer developer = _developerService.GetDeveloperById(developerId);
            if (developer == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(developer);
        }
        [HttpPost]
        public async Task<IActionResult> FotografDuzenle(int Id, Developer developer, IFormFile Image)
        {
            int developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
            if (developerId != Id)
            {
                return RedirectToAction("Hata", "Uye");
            }
            Developer findDeveloper = _developerService.GetDeveloperById(developerId);
            string guidImageName = Guid.NewGuid().ToString();
            if (await KurnazFileUploader.UpdateFile(Image, guidImageName, "ImagesDeveloper", guidImageName + Image.FileName, "defaultdeveloper.png") == true)
            {
                findDeveloper.Photo = guidImageName + Image.FileName;
                _developerService.Update(findDeveloper);
            }
            else
            {
                TempData["UpdateErrorMessage"] = "Fotograf Yüklenme Hatası Oluştu.";
                return RedirectToAction("FotografDuzenle");
            }

            TempData["AddSuccessMessage"] = "Fotograf Başarıyla Güncellendi.";
            return RedirectToAction("YazilimciProfil", "Uye");
        }


    }
}