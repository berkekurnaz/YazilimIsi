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
    public class AnasayfaController : Controller
    {

        IContactService _contactService = new ContactManager(new EfContactDal());

        public IActionResult Index()
        {
            return View(_contactService.GetAllContactMessages());
        }

    }
}