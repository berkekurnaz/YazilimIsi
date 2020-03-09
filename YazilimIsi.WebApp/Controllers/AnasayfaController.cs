using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        IUserService _userService = new UserManager(new EfUserDal());
        IOfferService _offerService = new OfferManager(new EfOfferDal());
        IBlogService _blogService = new BlogManager(new EfBlogDal());

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
            return View(_blogService.GetAllBlogArticlesByCategory("Yazilim"));
        }

        /* Anasayfa IsVerenBlog Sayfasi */
        public IActionResult IsVerenBlog()
        {
            return View(_blogService.GetAllBlogArticlesByCategory("Isveren"));
        }

        /* Anasayfa Iletisim Sayfasi */
        public IActionResult Iletisim()
        {
            return View();
        }



        /* **************************************************************************************************************** */



        /* Anasayfa Yazilim Isleri Sayfasi */
        public IActionResult Isler(int sayfa=1, [FromQuery] string sehir = null, [FromQuery] string anahtar = null, [FromQuery] string kategori = null, [FromQuery] string type = null, [FromQuery] string minPrice = null, [FromQuery] string maxPrice = null, [FromQuery] string minTime = null, [FromQuery] string maxTime = null)
        {
            List<Job> jobs = _jobService.GetAllJobs();
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();
            if (anahtar != null)
            {
                anahtar = anahtar.ToLower();
                ViewBag.JobSearchKey = anahtar;
                jobs = jobs.Where(x => x.Title.ToLower().Contains(anahtar)).ToList();
            }
            if (sehir != null)
            {
                if (sehir != "Bütün Konumlar")
                {
                    ViewBag.JobSearchCity = sehir;
                    jobs = jobs.Where(x => x.Location == sehir).ToList();
                }
            }
            if (kategori != null)
            {
                if (kategori != "Bütün İlanlar")
                {
                    ViewBag.JobSearchCategory = kategori;
                    jobs = jobs.Where(x => x.Category == kategori).ToList();
                }
            }
            if (minTime != null && maxTime != null)
            {
                ViewBag.JobSearchMinTime = minTime;
                ViewBag.JobSearchMaxTime = maxTime;
                jobs = jobs.Where(x => x.Time >= Convert.ToInt32(minTime) && x.Time <= Convert.ToInt32(maxTime)).ToList();
            }
            if (minPrice != null && maxPrice != null)
            {
                ViewBag.JobSearchMinPrice = minPrice;
                ViewBag.JobSearchMaxPrice = maxPrice;
                jobs = jobs.Where(x => x.Price >= Convert.ToInt32(minPrice) && x.Price <= Convert.ToInt32(maxPrice)).ToList();
            }


            anasayfaIslerViewModel.Jobs = PagingList.Create(jobs, 10, sayfa);

            anasayfaIslerViewModel.MyPagingModel = PagingList.Create(jobs, 10, sayfa);

            return View(anasayfaIslerViewModel);
        }
        [HttpPost]
        public IActionResult Isler(int sayfa = 1, string city = null, string key =null, string category=null, string minPrice = null, string maxPrice = null, string minTime = null, string maxTime = null)
        {
            List<Job> jobs = _jobService.GetAllJobs();
            if (key != null)
            {
                key = key.ToLower();
                ViewBag.JobSearchKey = key;
                jobs = jobs.Where(x => x.Title.ToLower().Contains(key)).ToList();
            }
            if (city != null)
            {
                if (city != "Bütün Konumlar")
                {
                    ViewBag.JobSearchCity= city;
                    jobs = jobs.Where(x => x.Location == city).ToList();
                }
            }
            if (category != null)
            {
                if (category != "Bütün İlanlar")
                {
                    ViewBag.JobSearchCategory = category;
                    jobs = jobs.Where(x => x.Category == category).ToList();
                }
            }
            if (minTime != null && maxTime != null)
            {
                if (minTime != "0")
                {
                    ViewBag.JobSearchMinTime = minTime;
                    ViewBag.JobSearchMaxTime = maxTime;
                    jobs = jobs.Where(x => x.Time >= Convert.ToInt32(minTime) && x.Time <= Convert.ToInt32(maxTime)).ToList();
                }
            }
            if (minPrice != null && maxPrice != null)
            {
                if(minPrice != "0")
                {
                    ViewBag.JobSearchMinPrice = minPrice;
                    ViewBag.JobSearchMaxPrice = maxPrice;
                    jobs = jobs.Where(x => x.Price >= Convert.ToInt32(minPrice) && x.Price <= Convert.ToInt32(maxPrice)).ToList();
                }
            }
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();
            anasayfaIslerViewModel.Jobs = PagingList.Create(jobs, 10, sayfa);

            anasayfaIslerViewModel.MyPagingModel = PagingList.Create(jobs, 10, sayfa);

            return View(anasayfaIslerViewModel);
        }

        /* Anasayfa Yazilim Isi Detay Sayfasi */
        public IActionResult IsDetay(int Id)
        {
            AnasayfaIslerViewModel anasayfaIslerViewModel = new AnasayfaIslerViewModel();

            Job job = _jobService.GetJobById(Id);
            if (job == null)
            {
                return RedirectToAction("Hata");
            }

            int developerId;
            if (HttpContext.Session.GetString("SessionDeveloperId") != null)
            {
                developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
                anasayfaIslerViewModel.Developer = _developerService.GetDeveloperById(developerId);

                /* Yazilimci Daha Once Teklif Vermis Mi Bulma Islemi */
                List<Offer> offerList = _offerService.GetOffersByJobId(Id);
                foreach (var item in offerList)
                {
                    if(item.DeveloperId == developerId)
                    {
                        anasayfaIslerViewModel.DeveloperOffer = item;
                    }
                }

            }

            anasayfaIslerViewModel.Job = job;
            return View(anasayfaIslerViewModel);
        }

        /* Anasayfa Yazilimci Teklif Yapma Islemi */
        public IActionResult TeklifYap(int Id, AnasayfaIslerViewModel anasayfaIslerViewModel)
        {
            int developerId;
            if (HttpContext.Session.GetString("SessionDeveloperId") != null)
            {
                developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
                bool flag = true;
                foreach (var item in _offerService.GetOffersByJobId(Id))
                {
                    if (item.DeveloperId == developerId)
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    Offer offer = anasayfaIslerViewModel.Offer;
                    offer.CreatedDate = DateTime.Now;
                    offer.JobId = Id;
                    offer.DeveloperId = developerId;
                    TempData["OfferMessage"] = "Başarılı Bir Şekilde Teklif Verdiniz.";
                    _offerService.Add(offer);
                }
                else
                {

                }
            }
            return RedirectToAction("IsDetay", new { Id = Id });
        }

        /* Anasayfa Yazilimci Teklif Duzenleme Islemi */
        public IActionResult TeklifDuzenle(int Id, int JobId, AnasayfaIslerViewModel anasayfaIslerViewModel)
        {
            int developerId;
            if (HttpContext.Session.GetString("SessionDeveloperId") != null)
            {
                developerId = Convert.ToInt32(HttpContext.Session.GetString("SessionDeveloperId"));
                Offer findOffer = _offerService.GetOfferById(Id);
                if (findOffer == null)
                {
                    return RedirectToAction("Hata");
                }
                findOffer.Price = anasayfaIslerViewModel.DeveloperOffer.Price;
                findOffer.Time = anasayfaIslerViewModel.DeveloperOffer.Time;
                findOffer.Description = anasayfaIslerViewModel.DeveloperOffer.Description;
                TempData["OfferMessage"] = "Başarılı Bir Şekilde Teklifi Güncellediniz.";
                _offerService.Update(findOffer);
            }
            return RedirectToAction("IsDetay", new { Id = JobId });
        }



        /* **************************************************************************************************************** */



        /* Yazilimci Herkese Acik Profil Sayfasi */
        public IActionResult Yazilimci(string name)
        {
            Developer developer = _developerService.GetDeveloperByUsername(name);
            if (developer == null)
            {
                return RedirectToAction("Hata");
            }
            return View(developer);
        }

        /* Isveren Herkese Acik Profil Sayfasi */
        public IActionResult Isveren(string name)
        {
            User user = _userService.GetUserByName(name);
            if (user == null)
            {
                return RedirectToAction("Hata");
            }
            ViewBag.UserCreatedJobs = _jobService.GetJobsByUserId(user.Id);
            return View(user);
        }



        /* **************************************************************************************************************** */



        /* Blog Sayfasi */
        public IActionResult Blog(string category)
        {
            // BU KISMI YAP...
            return View();
        }

        /* Blog Sayfasi Detay */
        public IActionResult BlogDetay(int Id)
        {
            // BU KISMI YAP...
            return View();
        }



    }
}