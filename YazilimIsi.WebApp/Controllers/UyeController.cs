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

namespace YazilimIsi.WebApp.Controllers
{
    public class UyeController : Controller
    {

        IDeveloperService _developerService = new DeveloperManager(new EfDeveloperDal());
        IUserService _userService = new UserManager(new EfUserDal());

        /* Yazilimci Profil Sayfasi */
        public IActionResult YazilimciProfil()
        {
            return View();
        }

        /* IsVeren Profil Sayfasi */
        public IActionResult UyeProfil()
        {
            return View();
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
            HttpContext.Session.SetString("SessionDeveloperId", developer.Id.ToString());
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
            HttpContext.Session.SetString("SessionUserId", user.Id.ToString());
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

    }
}