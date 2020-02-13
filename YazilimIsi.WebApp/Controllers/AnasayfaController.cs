using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YazilimIsi.Business.Abstract;
using YazilimIsi.Business.Concrete;
using YazilimIsi.DataAccess.Concrete;
using YazilimIsi.Entity.Models;

namespace YazilimIsi.WebApp.Controllers
{
    public class AnasayfaController : Controller
    {

        IContactService _contactService = new ContactManager(new EfContactDal());

        /* Anasayfa Index Sayfasi */
        public IActionResult Index()
        {
            return View();
        }

        /* Anasayfa Nedir Sayfasi */
        public IActionResult Nedir()
        {
            return View();
        }

        /* Anasayfa NasilCalisir Sayfasi */
        public IActionResult NasilCalisir()
        {
            return View();
        }

        /* Anasayfa Gelistiriciler Sayfasi */
        public IActionResult Gelistiriciler()
        {
            return View();
        }

        /* Anasayfa SSS Sayfasi */
        public IActionResult SSS()
        {
            return View();
        }

        /* Anasayfa YazilimBlog Sayfasi */
        public IActionResult YazilimBlog()
        {
            return View();
        }

        /* Anasayfa IsVerenBlog Sayfasi */
        public IActionResult IsVerenBlog()
        {
            return View();
        }

        /* Anasayfa Iletisim Sayfasi */
        public IActionResult Iletisim()
        {
            return View();
        }

    }
}