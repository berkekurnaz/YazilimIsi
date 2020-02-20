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
    public class IsverenController : Controller
    {

        IUserService _userService = new UserManager(new EfUserDal());
        IJobService _jobService = new JobManager(new EfJobDal());
        IOfferService _offerService = new OfferManager(new EfOfferDal());
        ISupportService _supportService = new SupportManager(new EfSupportDal());
        IAccountActivityService _accountActivityService = new AccountActivityManager(new EfAccountActivityDal());

        /* Isveren Yeni Is Olusturma */
        public IActionResult YeniIsOlustur()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniIsOlustur(Job job, IFormFile Image)
        {
            // İş Veren Bakiyesinden 1 TL Dusme
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            User user = _userService.GetUserById(userId);
            int userMoney = Convert.ToInt32(user.Money);
            if (userMoney < 1)
            {
                TempData["AddErrorMessage"] = "Hesabınızda Yeni Bir İlan Oluşturmak İçin Yeterli Bakiye Yoktur.";
                return View();
            }
            userMoney = userMoney - 1;
            user.Money = userMoney.ToString();
            _userService.Update(user);

            // Hesap Hareketlerine Bu Islemi Yazdirma
            AccountActivity accountActivity = new AccountActivity();
            accountActivity.Title = "İş İlanı Oluşturma Gideri";
            accountActivity.Description = "İş İlanı Oluşturulduğu İçin Hesabınızdan 1 TL Alınmıştır.";
            accountActivity.CreatedDate = DateTime.Now;
            accountActivity.IsIncrease = false;
            accountActivity.UserId = userId;
            accountActivity.Money = "1";
            _accountActivityService.Add(accountActivity);

            // Yeni Is İlanı Olusturma
            if (job.Title.Length == 0 || job.Description.Length == 0)
            {
                TempData["AddErrorMessage"] = "Lütfen Boş Alanları Doldurunuz.";
                return View();
            }

            job.CreatedDate = DateTime.Now;
            job.ViewCount = "0";
            job.UserId = userId;
            job.IsConfirm = false;
            job.IsCompleted = false;

            // Is Ilani Resim Kaydetme
            string guidImageName = Guid.NewGuid().ToString();
            if (await KurnazFileUploader.UploadFile(Image, guidImageName, "ImagesJob") == true)
            {
                job.Photo = guidImageName + Image.FileName;
            }

            _jobService.Add(job);

            TempData["AddSuccessMessage"] = "Oluşturduğunuz İlan Başarılı Bir Şekilde Sisteme Gönderildi. İnceleme İşlemlerinin Ardından Tarafınıza Bilgi Mesajı Gönderilecektir.";
            return RedirectToAction("UyeProfil","Uye");
        }

        /* Isveren Isleri Goruntuleme */
        public IActionResult Isler()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var userJobs = _jobService.GetJobsByUserId(userId);
            IsverenIslerViewModel isverenIslerViewModel = new IsverenIslerViewModel();
            isverenIslerViewModel.UserJobs = userJobs;
            isverenIslerViewModel.JobOfferCounts = _offerService.GettAllOffers();
            return View(isverenIslerViewModel);
        }

        /* Isveren Is Detayi Goruntuleme */
        public IActionResult IsDetay(int Id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            Job job = _jobService.GetJobById(Id);
            if (job == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (job.UserId != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            IsverenIsDetayViewModel isverenIsDetayViewModel = new IsverenIsDetayViewModel();
            isverenIsDetayViewModel.Job = job;
            isverenIsDetayViewModel.User = null;
            isverenIsDetayViewModel.Offers = _offerService.GetOffersByJobId(job.Id);
  
            return View(isverenIsDetayViewModel);
        }

        /* Isveren Ise Gelen Teklifi Goruntuleme */
        public IActionResult TeklifDetay(int Id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var offer = _offerService.GetOfferById(Id);
            if (offer == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if(offer.Job.UserId != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(offer);
        }

        /* Ilan Yayindan Kaldirma */
        public IActionResult YayindanKaldir(int Id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            Job job = _jobService.GetJobById(Id);
            if (job == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (job.UserId != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            job.IsCompleted = true;
            _jobService.Update(job);
            TempData["UpdateSuccessMessage"] = "İlanınız Yayından Başarıyla Kaldırıldı.";
            return RedirectToAction("UyeProfil", "Uye");
        }

        /* Ilan Tamamlama */
        public IActionResult Tamamlandir(int Id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            Job job = _jobService.GetJobById(Id);
            if (job == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (job.UserId != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            job.IsCompleted = true;
            _jobService.Update(job);
            TempData["UpdateSuccessMessage"] = "İlanınız Yayından Başarıyla Kaldırıldı.";
            return RedirectToAction("UyeProfil", "Uye");
        }

        /* Ilan Teklif Sikayet Etme */
        [HttpPost]
        public IActionResult TeklifSikayet(string Description)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            Support support = new Support();
            if (Description.Length < 10)
            {
                return View();
            }
            support.Title = "Yazılım Teklif Şikayeti";
            support.Description = Description;
            support.Category = "Teklif Şikayet";
            support.CreatedDate = DateTime.Now;
            support.IsCompleted = false;
            support.Username = userId.ToString();
            support.UserType = "User";
            _supportService.Add(support);
            TempData["AddSuccessMessage"] = "Oluşturduğunuz Şikayet Metni Başarıyla Gönderildi.";
            return RedirectToAction("UyeProfil", "Uye");
        }

        /* Isveren Hesap Hareketleri Sayfasi */
        public IActionResult HesapHareketleri()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            List<AccountActivity> activities = _accountActivityService.GetAllAccountActivitiesByUserId(userId);
            return View(activities);
        }

        /* Isveren Hesap Hareketi Detay Sayfasi */
        public IActionResult HesapHareketDetay(int Id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            AccountActivity accountActivity = _accountActivityService.GetAccountActivityById(Id);
            if (accountActivity == null)
            {
                return RedirectToAction("Hata", "Uye");
            }
            if (accountActivity.UserId != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(accountActivity);
        }

    }
}