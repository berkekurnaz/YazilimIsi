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
    public class UyeController : Controller
    {

        IDeveloperService _developerService = new DeveloperManager(new EfDeveloperDal());
        IUserService _userService = new UserManager(new EfUserDal());
        IJobService _jobService = new JobManager(new EfJobDal());
        IOfferService _offerService = new OfferManager(new EfOfferDal());

        /* Yazilimci Profil Sayfasi */
        public IActionResult YazilimciProfil()
        {
            int developerId;
            if (HttpContext.Session.GetString("SessionDeveloperId") == null)
            {
                return RedirectToAction("Index", "Anasayfa");
            }
            developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));

            return View(_developerService.GetDeveloperById(developerId));
        }

        /* IsVeren Profil Sayfasi */
        public IActionResult UyeProfil()
        {
            int userId;
            if (HttpContext.Session.GetString("SessionUserId") == null)
            {
                return RedirectToAction("Index", "Anasayfa");
            }
            userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));

            UserViewModels userViewModels = new UserViewModels();
            userViewModels.User = _userService.GetUserById(userId);
            userViewModels.UserJobs = _jobService.GetJobsByUserId(userId);

            ViewBag.UserCreatedJobsCount = _jobService.GetJobsByUserId(userId).Count.ToString();
            ViewBag.UserCreatedAndCompletedJobsCount = _jobService.GetJobsByUserId(userId).Where(x => x.IsCompleted == true).ToList().Count.ToString();
            ViewBag.UserJobsOffersCount = _offerService.GetOffersByUserId(userId).Count.ToString();

            return View(userViewModels);
        }

        /* Uyeler Icin Giris Sayfasi */
        public IActionResult Giris()
        {
            return View();
        }

        /* Uye Olmak Isteyenler Icin Kayit Olma Sayfasi */
        public IActionResult UyeOl()
        {
            return View();
        }

        /* Yazilimci Giris Yapma Sayfasi */
        public IActionResult YazilimciGiris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YazilimciGiris(Developer developer)
        {
            // var userId = HttpContext.Session.GetString("SessionUserId").ToString();
            if (!_developerService.DeveloperLoginCheck(developer.Username, developer.Password))
            {
                TempData["LogInErrorMessage"] = "Kullanıcı Adını Veya Şifreyi Hatalı Girdiniz";
                return View();
            }
            var developerId = _developerService.GetAllDevelopers().Where(x => x.Username == developer.Username && x.Password == developer.Password).SingleOrDefault().Id;
            HttpContext.Session.SetString("SessionDeveloperId", developerId.ToString());
            return RedirectToAction("UyeProfil");
        }

        /* Is Veren Giris Yapma Sayfasi */
        public IActionResult IsVerenGiris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IsVerenGiris(User user)
        {
            if (!_userService.UserLoginCheck(user.Username, user.Password))
            {
                TempData["LogInErrorMessage"] = "Kullanıcı Adını Veya Şifreyi Hatalı Girdiniz";
                return View();
            }
            var userId = _userService.GetAllUsers().Where(x => x.Username == user.Username && x.Password == user.Password).SingleOrDefault().Id;
            HttpContext.Session.SetString("SessionUserId", userId.ToString());
            return RedirectToAction("YazilimciProfil");
        }

        /* Yazilimci Uye Olma Yapma Sayfasi */
        public IActionResult YazilimciUyeOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YazilimciUyeOl(Developer developer)
        {
            if (developer.Username.Length < 1 || developer.Password.Length < 1 || developer.Mail.Length < 1)
            {
                TempData["SignInErrorMessage"] = "Lütfen Gerekli Alanları Doldurunuz";
                return View();
            }
            if (!_developerService.DeveloperUsernameCheck(developer.Username))
            {
                TempData["SignInErrorMessage"] = "Bu Kullanıcı Adı Sistemde Kullanılmaktadır. Lütfen Farklı Bir Kullanıcı Adı İle Üye Olmayı Deneyiniz.";
                return View();
            }
            if (!_developerService.DeveloperMailCheck(developer.Mail))
            {
                TempData["SignInErrorMessage"] = "Bu Mail Hesabı Sistemde Kullanılmaktadır. Lütfen Farklı Bir Mail Hesabı İle Üye Olmayı Deneyiniz.";
                return View();
            }
            developer.CreatedDate = DateTime.Now;
            developer.IsConfirm = false;
            developer.Money = "2";
            _developerService.Add(developer);
            return RedirectToAction("UyelikBasari");
        }

        /* Is Veren Uye Olma Yapma Sayfasi */
        public IActionResult IsVerenUyeOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IsVerenUyeOl(User user)
        {
            if (user.Username.Length < 1 || user.Password.Length < 1 || user.Mail.Length < 1)
            {
                TempData["SignInErrorMessage"] = "Lütfen Gerekli Alanları Doldurunuz";
                return View();
            }
            if (!_userService.UserUsernameCheck(user.Username))
            {
                TempData["SignInErrorMessage"] = "Bu Kullanıcı Adı Sistemde Kullanılmaktadır. Lütfen Farklı Bir Kullanıcı Adı İle Üye Olmayı Deneyiniz.";
                return View();
            }
            if (!_userService.UserMailCheck(user.Mail))
            {
                TempData["SignInErrorMessage"] = "Bu Mail Hesabı Sistemde Kullanılmaktadır. Lütfen Farklı Bir Mail Hesabı İle Üye Olmayı Deneyiniz.";
                return View();
            }
            user.CreatedDate = DateTime.Now;
            user.IsConfirm = false;
            user.Money = "2";
            _userService.Add(user);
            return RedirectToAction("UyelikBasari");
        }

        /* Uye Olduktan Sonra Sayfa */
        public IActionResult UyelikBasari()
        {
            return View();
        }

        /* Uye Cikis Islemi */
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Anasayfa");
        }

        /* Hata Sayfası */
        public IActionResult Hata()
        {
            return View();
        }

    }
}