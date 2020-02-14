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
    public class IsverenController : Controller
    {

        IUserService _userService = new UserManager(new EfUserDal());

        /* Isveren Yeni Is Olusturma */
        public IActionResult YeniIsOlustur()
        {
            return View();
        }

        /* Isveren Isleri Goruntuleme */
        public IActionResult Isler()
        {
            return View();
        }

        /* Isveren Is Detayi Goruntuleme */
        public IActionResult IsDetay()
        {
            return View();
        }

    }
}