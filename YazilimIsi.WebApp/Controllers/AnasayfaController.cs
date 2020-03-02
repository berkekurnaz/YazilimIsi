using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using YazilimIsi.Business.Abstract;
using YazilimIsi.Business.Concrete;
using YazilimIsi.DataAccess.Concrete;
using YazilimIsi.Entity.Models;
using YazilimIsi.WebApp.Models;

namespace YazilimIsi.WebApp.Controllers
{
    public class AnasayfaController : Controller
    {

        IContactService _contactService = new ContactManager(new EfContactDal());
        IJobService _jobService = new JobManager(new EfJobDal());
        IDeveloperService _developerService = new DeveloperManager(new EfDeveloperDal());

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



        /* **************************************************************************************************************** */



        /* Anasayfa Yazilim Isleri Sayfasi */
        public IActionResult Isler(int sayfa=1)
        {
            List<Job> jobs = _jobService.GetAllJobs();
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();
            anasayfaIslerViewModel.Jobs = PagingList.Create(jobs, 5, sayfa);

            anasayfaIslerViewModel.MyPagingModel = PagingList.Create(jobs, 5, sayfa);

            return View(anasayfaIslerViewModel);
        }
        [HttpPost]
        public IActionResult Isler([FromQuery] string sehir, [FromQuery] string key, [FromQuery] string category)
        {
            List<Job> jobs = _jobService.GetAllJobs();
            if (sehir != null)
            {
                jobs = jobs.Where(x => x.Location == sehir).ToList();
            }
            if (category != null)
            {
                jobs = jobs.Where(x => x.Category == category).ToList();
            }
            if (key != null)
            {
                jobs = jobs.Where(x => x.Title.Contains(key)).ToList();
            }
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();
            anasayfaIslerViewModel.Jobs = jobs;
            return View(anasayfaIslerViewModel);
        }

        /* Anasayfa Yazilim Isi Detay Sayfasi */
        public IActionResult IsDetay(int Id)
        {
            Job job = _jobService.GetJobById(Id);
            if (job == null)
            {
                return RedirectToAction("Hata");
            }
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();
            anasayfaIslerViewModel.Job = job;
            return View(anasayfaIslerViewModel);
        }







    }
}