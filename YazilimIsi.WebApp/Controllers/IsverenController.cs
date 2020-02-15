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
    public class IsverenController : Controller
    {

        IUserService _userService = new UserManager(new EfUserDal());
        IJobService _jobService = new JobManager(new EfJobDal());

        /* Isveren Yeni Is Olusturma */
        public IActionResult YeniIsOlustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniIsOlustur(Job job)
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
            _jobService.Add(job);

            TempData["AddSuccessMessage"] = "Oluşturduğunuz İlan Başarılı Bir Şekilde Sisteme Gönderildi. İnceleme İşlemlerinin Ardından Tarafınıza Bilgi Mesajı Gönderilecektir.";
            return RedirectToAction("UyeProfil","Uye");
        }

        /* Isveren Isleri Goruntuleme */
        public IActionResult Isler()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("SessionUserId"));
            var userJobs = _jobService.GetJobsByUserId(userId);
            return View(userJobs);
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
            if (job.Id != userId)
            {
                return RedirectToAction("Hata", "Uye");
            }
            return View(job);
        }

    }
}